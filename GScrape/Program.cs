using GScrape.Clients;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace GScrape
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<TimeoutRejectedException>() // thrown by Polly's TimeoutPolicy if the inner call times out
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                });

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10); // Timeout for an individual try

            //setup our DI
            var serviceCollection = new ServiceCollection()
                .AddLogging(x => x.AddConsole())
                .AddLogging()
                .AddScoped<IScraperWorker, ScraperWorker>()
                .AddLogging(x => x.AddConsole());

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args ?? new string[0])
                .Build();
            serviceCollection.AddSingleton(config);

            serviceCollection.AddRefitClient<INeweggClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("https://www.newegg.com");
                    client.Timeout = TimeSpan.FromSeconds(60); // Overall timeout across all tries
                })
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy); // We place the timeoutPolicy inside the retryPolicy, to make it time out each try.

            serviceCollection.AddMediatR(typeof(Program).Assembly);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Starting application");


            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                // Creating a task to listen to keyboard key press
                var keyBoardTask = Task.Run(() =>
                {
                    Console.WriteLine("Press enter to cancel");
                    Console.ReadKey();

                    // Cancel the task
                    cancellationTokenSource.Cancel();
                });

                var gWowModWorker = serviceProvider.GetService<IScraperWorker>();

                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    var exceptions = new List<Exception>();
                    
                    try
                    {
                        if (exceptions.Count > 25)
                        {
                            Console.WriteLine("25 errors reached - pausing for an hour");
                            Thread.Sleep(TimeSpan.FromHours(1));
                            
                            exceptions.Clear();
                        }
                        
                        await gWowModWorker.DoWork();

                        var randomInterval = RandomNumberGenerator.GetInt32(45, 90);
                        Thread.Sleep(TimeSpan.FromSeconds(randomInterval));
                    }
                    catch (Exception e)
                    {
                        exceptions.Add(e);
                        Console.WriteLine(e);
                    }
                }
                
                logger.LogDebug("All done!");
            }
        }
    }
}
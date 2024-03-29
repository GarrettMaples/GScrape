﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider(args);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogInformation("Starting application");

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

                var exceptionCount = 0;

                using (var scope = serviceProvider.CreateScope())
                {
                    var worker = scope.ServiceProvider.GetService<IScraperWorker>();

                    while (!cancellationTokenSource.IsCancellationRequested)
                    {
                        try
                        {
                            if (exceptionCount > 25)
                            {
                                logger.LogError("25 errors reached - pausing for an hour");
                                Thread.Sleep(TimeSpan.FromHours(1));

                                exceptionCount = 0;
                            }

                            logger.LogInformation("Starting Work");
                            await worker.DoWork();
                            logger.LogInformation("Ending Work");

                            //Clear exceptions after every success
                            exceptionCount = 0;

                            var randomInterval = RandomNumberGenerator.GetInt32(10, 15);
                            Thread.Sleep(TimeSpan.FromSeconds(randomInterval));
                        }
                        catch (Exception e)
                        {
                            exceptionCount++;
                            logger.LogError(e.ToString());

                            var randomInterval = RandomNumberGenerator.GetInt32(10, 15);
                            Thread.Sleep(TimeSpan.FromSeconds(randomInterval));
                        }
                    }
                }

                logger.LogInformation("Exiting Application");
            }
        }

        private static ServiceProvider BuildServiceProvider(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                .AddScoped<IScraperWorker, ScraperWorker>();

            serviceCollection.AddGScrape();

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args ?? new string[0])
                .Build();
            serviceCollection.AddSingleton(config);

            serviceCollection.AddMediatR(typeof(Program).Assembly);

            return serviceCollection.BuildServiceProvider();
        }
    }
}
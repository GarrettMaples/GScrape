using GScrape.Clients;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using Refit;
using System;
using System.Net.Http;

namespace GScrape
{
    public static class Bootstrapper
    {
        public static void Boostrap(IServiceCollection services)
        {
            services
                .AddLogging(x => x.AddConsole())
                .AddLogging()
                .AddScoped<IScraperWorker, ScraperWorker>()
                .AddLogging(x => x.AddConsole());

            services.AddMediatR(typeof(Program).Assembly);

            ConfigureHttpClients(services);
        }

        private static void ConfigureHttpClients(IServiceCollection serviceCollection)
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

            serviceCollection.AddRefitClient<INeweggClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("https://www.newegg.com");
                    client.Timeout = TimeSpan.FromSeconds(60); // Overall timeout across all tries
                })
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy); // We place the timeoutPolicy inside the retryPolicy, to make it time out each try.
        }
    }
}
using GScrape.Clients;
using GScrape.Requests;
using GScrape.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
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
                .AddScoped<IEmailer, Emailer>()
                .AddScoped<IPipelineBehavior<ScrapeResult, Unit>, NotificationCacheBehavior>()
                .AddLogging(x => x.AddConsole());

            services.AddMediatR(typeof(Program).Assembly);
            
            var types =
                services.BuildServiceProvider().Get.GetTypesToRegister(typeof(IRequestHandler<,>), assemblies,
                    new TypesToRegisterOptions { IncludeGenericTypeDefinitions = true });

            container.Register(typeof(IRequestHandler<,>), types);
            
            services.AddTransient(typeof(IRequestHandler<NotificationRequest<>>), typeof(NotificationRequestHandler<>))

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

            serviceCollection.AddRefitClient<IOfficeDepotClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(Requests.OfficeDepot.ScrapeSearchRequestHandler.BaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(60); // Overall timeout across all tries
                })
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy); // We place the timeoutPolicy inside the retryPolicy, to make it time out each try.

            serviceCollection.AddRefitClient<IBestBuyClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(Requests.BestBuy.ScrapeRequestHandler.BaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(60); // Overall timeout across all tries
                    client.DefaultRequestHeaders.Add("Connection", new[] { "keep-alive", "Transfer-Encoding" });
                    client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", new[] { "1" });
                    client.DefaultRequestHeaders.Add("User-Agent",
                        new[] { "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36" });
                    client.DefaultRequestHeaders.Add("Accept",
                        new[] { "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9" });
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Site", new[] { "none" });
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", new[] { "navigate" });
                    client.DefaultRequestHeaders.Add("Sec-Fetch-User", new[] { "?1" });
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", new[] { "document" });
                    client.DefaultRequestHeaders.Add("Accept-Encoding", new[] { "UTF-8" });
                    client.DefaultRequestHeaders.Add("Accept-Language", new[] { "en-US,en;q=0.9" });
                })
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy); // We place the timeoutPolicy inside the retryPolicy, to make it time out each try.

            serviceCollection.AddRefitClient<IAmazonClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(Requests.Amazon.ScrapeRequestHandler.BaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(60); // Overall timeout across all tries
                })
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy); // We place the timeoutPolicy inside the retryPolicy, to make it time out each try.

            serviceCollection.AddHttpClient();

            var builder = new HttpClientBuilder(serviceCollection, "DefaultClient");

            builder.Services.AddTransient(s =>
            {
                var httpClientFactory = s.GetRequiredService<IHttpClientFactory>();
                var client = httpClientFactory.CreateClient("DefaultClient");

                client.Timeout = TimeSpan.FromSeconds(60); // Overall timeout across all tries

                return client;
            });

            builder.AddHttpMessageHandler(() => new PolicyHttpMessageHandler(retryPolicy));
            builder.AddHttpMessageHandler(() => new PolicyHttpMessageHandler(timeoutPolicy));
        }

        private class HttpClientBuilder : IHttpClientBuilder
        {
            public HttpClientBuilder(IServiceCollection services, string name)
            {
                Services = services;
                Name = name;
            }

            public string Name { get; }
            public IServiceCollection Services { get; }
        }
    }
}
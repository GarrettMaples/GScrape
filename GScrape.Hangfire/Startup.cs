using GScrape.Hangfire.Jobs;
using Hangfire;
using Hangfire.Common;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace GScrape.Hangfire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection")));

            services.AddHangfireServer();

            services.AddMediatR(typeof(Program).Assembly);

            services.AddGScrape();

            var hangfireJobType = typeof(IHangfireJob);
            foreach (var type in hangfireJobType.Assembly.GetTypes().Where(x => !x.IsInterface && hangfireJobType.IsAssignableFrom(x)))
            {
                services.AddSingleton(hangfireJobType, type);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IRecurringJobManager recurringJobManager, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard(options: new DashboardOptions
                {
                    Authorization = new[] { new AllowAllConnectionsFilter() },
                    IgnoreAntiforgeryToken = true
                });
            });

            var jobs = app.ApplicationServices.GetServices<IHangfireJob>();

            foreach (var job in jobs)
            {
                var hangfireJob = new Job(job.GetType().GetMethod(nameof(IHangfireJob.DoWork)));
                recurringJobManager.AddOrUpdate(job.GetType().ToString(), hangfireJob, job.CronExpression);
            }
        }
    }

    public class AllowAllConnectionsFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
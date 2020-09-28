using System.Threading.Tasks;

namespace GScrape.Hangfire.Jobs
{
    public interface IHangfireJob
    {
        public string CronExpression { get; }
        Task DoWork();
    }
}
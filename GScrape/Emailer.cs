using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape
{
    public interface IEmailer
    {
        Task SendEmail(MimeMessage message, CancellationToken cancellationToken);
    }

    internal class Emailer : IEmailer
    {
        private readonly IConfiguration _configuration;

        public Emailer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(MimeMessage message, CancellationToken cancellationToken)
        {
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_configuration.GetValue<string>("EmailServerHost"), 587, false, cancellationToken);
                await client.AuthenticateAsync(_configuration.GetValue<string>("EmailServerUsername"), _configuration.GetValue<string>("EmailServerPassword"), cancellationToken);
                await client.SendAsync(message, cancellationToken);
            }
        }
    }
}
using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Results
{
    public class ScrapeResult : IRequest
    {
        public KeyValuePair<string, IEnumerable<(string itemName, string itemLink)>> Results { get; set; }
    }

    internal class ScrapeResultHandler : IRequestHandler<ScrapeResult>
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ScrapeResultHandler> _logger;

        public ScrapeResultHandler(IConfiguration configuration, ILogger<ScrapeResultHandler> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<Unit> Handle(ScrapeResult request, CancellationToken cancellationToken)
        {
            var results = request.Results.Value.ToList();

            if (!results.Any())
            {
                return Unit.Value;
            }

            var message = new MimeMessage();

            var from = new MailboxAddress("no-reply", "no-reply@gscraper.com");
            message.From.Add(from);

            foreach (var email in _configuration.GetValue<string>("ToEmailAddresses").Split(','))
            {
                var to = new MailboxAddress("User", email);
                message.To.Add(to);
            }

            message.Subject = $"{request.Results.Key} Stock Found!";

            var stringBuilder = new StringBuilder();
            foreach (var (itemName, itemLink) in results)
            {
                stringBuilder.AppendLine($"Name: {itemName}{Environment.NewLine}Link: {itemLink}{Environment.NewLine}");
            }

            var bodyBuilder = new BodyBuilder { TextBody = stringBuilder.ToString() };
            message.Body = bodyBuilder.ToMessageBody();

            await SendEmail(message, cancellationToken);

            return Unit.Value;
        }

        private async Task SendEmail(MimeMessage message, CancellationToken cancellationToken)
        {
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_configuration.GetValue<string>("EmailServerHost"), 587, false, cancellationToken);
                await client.AuthenticateAsync(_configuration.GetValue<string>("EmailServerUsername"), _configuration.GetValue<string>("EmailServerPassword"), cancellationToken);
                await client.SendAsync(message, cancellationToken);
            }

            _logger.LogInformation("Email Sent.");
        }
    }
}
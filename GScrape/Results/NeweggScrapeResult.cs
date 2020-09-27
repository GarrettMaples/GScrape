using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Results
{
    public class NeweggScrapeResult : IRequest
    {
        public IEnumerable<(string itemName, string itemLink)> Results { get; set; }
    }

    internal class NeweggScrapeResultHandler : IRequestHandler<NeweggScrapeResult>
    {
        private readonly IConfiguration _configuration;

        public NeweggScrapeResultHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Unit> Handle(NeweggScrapeResult request, CancellationToken cancellationToken)
        {
            var results = request.Results.ToList();
            if (!results.Any())
            {
                return Unit.Value;
            }

            var message = new MimeMessage();

            var from = new MailboxAddress("no-reply", "no-reply@gscraper.com");
            message.From.Add(from);

            var to = new MailboxAddress("User", _configuration.GetValue<string>("EmailAddress"));
            message.To.Add(to);

            message.Subject = "Newegg 3090 RTX Stock Found!";

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
                await client.ConnectAsync(_configuration.GetValue<string>("EmailHost"), 587, false, cancellationToken);
                await client.AuthenticateAsync(_configuration.GetValue<string>("EmailAddress"), _configuration.GetValue<string>("EmailPassword"), cancellationToken);
                await client.SendAsync(message, cancellationToken);
            }
        }
    }
}
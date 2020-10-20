using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Results
{
    public class ItemPriceScrapeItem : ScrapeItem
    {
        public ItemPriceScrapeItem(string name, string link, string itemId, decimal price)
            : base(name, link, itemId)
        {
            Price = price;
        }

        public decimal Price { get; }
    }

    internal class ItemPriceScrapeResultHandler : IRequestHandler<ScrapeResult<ItemPriceScrapeItem>>
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailer _emailer;
        private readonly ILogger<ScrapeResultHandler> _logger;

        public ItemPriceScrapeResultHandler(IConfiguration configuration, IEmailer emailer, ILogger<ScrapeResultHandler> logger)
        {
            _configuration = configuration;
            _emailer = emailer;
            _logger = logger;
        }

        public async Task<Unit> Handle(ScrapeResult<ItemPriceScrapeItem> request, CancellationToken cancellationToken)
        {
            var results = await request.ScrapeItems.ToListAsync(cancellationToken);

            if (!results.Any())
            {
                return Unit.Value;
            }

            _logger.LogInformation($"Attempting to send emails for ${request.RequestName}.");

            var message = new MimeMessage();

            var from = new MailboxAddress("no-reply", "no-reply@gscraper.com");
            message.From.Add(from);

            foreach (var email in _configuration.GetValue<string>("ToEmailAddresses").Split(','))
            {
                var to = new MailboxAddress("User", email);
                message.To.Add(to);
            }

            message.Subject = $"{request.RequestName} Price Decrease Detected!";

            var stringBuilder = new StringBuilder();
            foreach (var result in results.Cast<ItemPriceScrapeItem>())
            {
                stringBuilder.AppendLine($"Name: {result.Name}");
                stringBuilder.AppendLine($"Price: {result.Price:C}");
                stringBuilder.AppendLine($"Link: {result.Link}");
            }

            var bodyBuilder = new BodyBuilder { TextBody = stringBuilder.ToString() };
            message.Body = bodyBuilder.ToMessageBody();

            await _emailer.SendEmail(message, cancellationToken);

            _logger.LogInformation($"Emails sent for ${request.RequestName}.");

            return Unit.Value;
        }
    }
}
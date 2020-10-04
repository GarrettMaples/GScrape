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
    public class ScrapeResult : IRequest
    {
        public ScrapeResult(string requestName, IAsyncEnumerable<ScrapeItem> scrapeItems)
        {
            RequestName = requestName;
            ScrapeItems = scrapeItems ?? AsyncEnumerable.Empty<ScrapeItem>();
        }

        public string RequestName { get; }

        public IAsyncEnumerable<ScrapeItem> ScrapeItems { get; set; }

        public string ResultId { get; } = nameof(ScrapeResult);
    }

    public class ScrapeItem
    {
        public ScrapeItem(string itemName, string itemLink, string itemId)
        {
            ItemName = itemName;
            ItemLink = itemLink;
            ItemId = itemId;
        }

        public string ItemName { get; }
        public string ItemLink { get; }
        public string ItemId { get; }
    }

    internal class ScrapeResultHandler : IRequestHandler<ScrapeResult>
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailer _emailer;

        public ScrapeResultHandler(IConfiguration configuration, IEmailer emailer)
        {
            _configuration = configuration;
            _emailer = emailer;
        }

        public async Task<Unit> Handle(ScrapeResult request, CancellationToken cancellationToken)
        {
            var results = await request.ScrapeItems.ToListAsync(cancellationToken);

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

            message.Subject = $"{request.RequestName} Stock Found!";

            var stringBuilder = new StringBuilder();
            foreach (var result in results)
            {
                stringBuilder.AppendLine($"Name: {result.ItemName}{Environment.NewLine}Link: {result.ItemLink}{Environment.NewLine}");
            }

            var bodyBuilder = new BodyBuilder { TextBody = stringBuilder.ToString() };
            message.Body = bodyBuilder.ToMessageBody();

            await _emailer.SendEmail(message, cancellationToken);

            return Unit.Value;
        }
    }
}
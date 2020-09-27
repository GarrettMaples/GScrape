using GScrape.Clients;
using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests
{
    public class NeweggScrapeRequest : IRequest
    {
        
    }
    
    internal class NeweggScrapeRequestHandler : IRequestHandler<NeweggScrapeRequest>
    {
        private readonly INeweggClient _neweggClient;
        private readonly IConfiguration _configuration;
        
        private readonly Regex _itemContainerRegex = new Regex(@"<div class=""item-container"">(.*?)<\/div><\/div><\/div>", RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(10));
        private readonly Regex _itemPromoRegex = new Regex(@"<p class=""item-promo"">(.*?)<\/p>", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(10));
        private readonly Regex _itemInfoRegex =
            new Regex(@"<div class=""item-branding"">.*?<\/a><\/div><a href=""(?<link>[^""]*)"".*?>(?<name>.*?)<\/a>", RegexOptions.Compiled | RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(10));

        public NeweggScrapeRequestHandler(INeweggClient neweggClient, IConfiguration configuration)
        {
            _neweggClient = neweggClient;
            _configuration = configuration;
        }

        public async Task<Unit> Handle(NeweggScrapeRequest request, CancellationToken cancellationToken)
        {
            var html3090Page = await _neweggClient.Get3090SearchPage();

            var individual3090Matches = _itemContainerRegex.Matches(html3090Page);

            foreach (Match match3090 in individual3090Matches)
            {
                var itemPromoMatch = _itemPromoRegex.Match(match3090.Value);

                if (itemPromoMatch.Success && itemPromoMatch.Value.Contains("OUT OF STOCK", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var infoMatch = _itemInfoRegex.Match(match3090.Value);

                if (infoMatch.Success)
                {
                    var link = infoMatch.Groups["link"].Value;
                    var name = infoMatch.Groups["name"].Value;
                        
                    var message = new MimeMessage();

                    var from = new MailboxAddress("no-reply", 
                        "no-reply@gscraper.com");
                    message.From.Add(@from);

                    var to = new MailboxAddress("User", 
                        _configuration.GetValue<string>("EmailAddress"));
                    message.To.Add(to);

                    message.Subject = "Newegg 3090 RTX Stock Found!";
                        
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = $"Name: {name}{Environment.NewLine}Link: {link}";
                    message.Body = bodyBuilder.ToMessageBody();

                    await SendEmail(message, cancellationToken);
                }
                else
                {
                    var message = new MimeMessage();

                    var from = new MailboxAddress("no-reply", 
                        "no-reply@gscraper.com");
                    message.From.Add(@from);

                    var to = new MailboxAddress("User", 
                        _configuration.GetValue<string>("EmailAddress"));
                    message.To.Add(to);

                    message.Subject = "Newegg 3090 RTX Stock Found!";
                        
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = $"Stock found but unable to determine name or link.";
                    message.Body = bodyBuilder.ToMessageBody();
                        
                    await SendEmail(message, cancellationToken);
                }
            }

            return Unit.Value;
        }
        
        private async Task SendEmail(MimeMessage message, CancellationToken cancellationToken)
        {
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_configuration.GetValue<string>("EmailHost"), 587,  false, cancellationToken);
                await client.AuthenticateAsync(_configuration.GetValue<string>("EmailAddress"), _configuration.GetValue<string>("EmailPassword"), cancellationToken);
                await client.SendAsync(message, cancellationToken);
            }
        }
    }
}
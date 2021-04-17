using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Core.Interfaces;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Services
{
    public class EmailSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; }

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public async Task<MailjetResponse> SendEmailAsync(string email, string subject, string message)
        {
            MailjetClient client = new MailjetClient(Options.ApiKey, Options.ApiSecret);

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }.Property(Send.Messages, new JArray {
                 new JObject {
                  {
                   "From",
                   new JObject {
                    {"Email", Options.FromEmail},
                    {"Name", Options.FromName}
                   }
                  }, {
                   "To",
                   new JArray {
                    new JObject {
                     {
                      "Email",
                      email
                     }
                    }
                   }
                  }, {
                   "Subject",
                    subject
                  },{
                   "HTMLPart",
                   message
                  }
                 }
                });

            return await client.PostAsync(request);
        }
    }
}

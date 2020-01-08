using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Core.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
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

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(Options.Username)
            };

            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.Subject = subject;

            var client = new SmtpClient(Options.Server)
            {
                Port = Options.Port,
                EnableSsl = Options.EnableSsl,
                Credentials = new NetworkCredential(Options.Username, Options.Password)
            };

            return client.SendMailAsync(mailMessage);
        }
    }
}

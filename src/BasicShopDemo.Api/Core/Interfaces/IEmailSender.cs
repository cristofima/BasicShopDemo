using Mailjet.Client;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Core.Interfaces
{
    public interface IEmailSender
    {
        Task<MailjetResponse> SendEmailAsync(string email, string subject, string message);
    }
}

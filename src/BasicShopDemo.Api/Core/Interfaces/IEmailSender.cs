using System.Threading.Tasks;

namespace BasicShopDemo.Api.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

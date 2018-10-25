using System.Threading.Tasks;

namespace Project_Edelweiss.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

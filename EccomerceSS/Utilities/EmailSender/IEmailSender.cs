using EccomerceSS.ViewModel;
using System.Threading.Tasks;

namespace EccomerceSS.Utilities.EmailSender
{
    public interface IEmailSender
    {
        Task SendAsync(RegisterUserViewModel model, string subject, string body);
    }
}

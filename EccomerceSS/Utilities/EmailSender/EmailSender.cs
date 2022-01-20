using EccomerceSS.Models;
using EccomerceSS.ViewModel;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EccomerceSS.Utilities.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private string path = Path.Combine
            (new DirectoryInfo(Directory.GetCurrentDirectory()).FullName, "Utilities", "EmailSender","ConfirmationEmailLayout.txt");
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendAsync(RegisterUserViewModel model, string subject, string body)
        {
            string emailConfirmationHTMLBody = File.ReadAllText(path);
            emailConfirmationHTMLBody = emailConfirmationHTMLBody.Replace("{user}", model.UserName).Replace("{urlConfirmation}", body);
            var json= _config.GetSection(DataJsonEntity.EmailAccount).Get<DataJsonEntity>();
            var fromAddress = new MailAddress(json.email);
            var fromPassword = json.password;
            var toAddress = new MailAddress(model.Email);

            SmtpClient smtp = new SmtpClient
            {
                Host = json.provider,
                Port = int.Parse(json.port),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = emailConfirmationHTMLBody,
                IsBodyHtml = true
            })
            await smtp.SendMailAsync(message);
            
        }
    }

}


using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using email_service.Helper;
using email_service.Models;
using Microsoft.Extensions.Options;

namespace email_service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IEmailGenerator _emailGenerator;

        public EmailService(IOptions<EmailSettings> mailSettings, IEmailGenerator emailGenerator)
        {
            _emailSettings = mailSettings.Value;
            _emailGenerator = emailGenerator;
        }

        public async Task SendRegisterEmail(string email)
        {
            await SendEmail(email, _emailGenerator.CreateRegisterEmail());
        }

        private async Task SendEmail(string to, Email email)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_emailSettings.Email),
            };

            mail.To.Add(new MailAddress(to));
            mail.Subject = email.Subject;
            mail.Body = email.Body;
            mail.IsBodyHtml = true;

            using var smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password),
                EnableSsl = _emailSettings.Ssl
            };

            await smtp.SendMailAsync(mail);
        }
    }
}
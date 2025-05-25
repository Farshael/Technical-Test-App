using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TechnicalTest.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _cfg;
        public EmailSender(IOptions<EmailSettings> options)
        {
            _cfg = options.Value;
        }

        public Task SendEmailAsync(string to, string subject, string htmlMessage)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_cfg.FromAddress, _cfg.FromName),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mail.To.Add(to);

            var client = new SmtpClient(_cfg.SmtpServer, _cfg.SmtpPort)
            {
                Credentials = new NetworkCredential(_cfg.SmtpUsername, _cfg.SmtpPassword),
                EnableSsl = true,
                Timeout = 20000
            };

            return client.SendMailAsync(mail);
        }
    }
}

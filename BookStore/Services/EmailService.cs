using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BookStore.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _mailConfig;

        public EmailService(IConfiguration configuration)
        {
            _mailConfig = configuration;
        }

        public async Task SendMail(string subject, string toEmail, string message)
        {
            using (var client = new SmtpClient())
            {
                client.UseDefaultCredentials = false;
                var credential = new NetworkCredential
                {
                    UserName = _mailConfig["Email:From"],
                    Password = _mailConfig["Email:Password"]
                };

                client.Credentials = credential;
                client.Host = _mailConfig["Email:Host"];
                client.Port = int.Parse(_mailConfig["Email:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(toEmail));
                    emailMessage.From = new MailAddress(_mailConfig["Email:From"]);
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
        }
    }
}

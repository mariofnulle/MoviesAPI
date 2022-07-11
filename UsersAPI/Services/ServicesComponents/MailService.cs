using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using UsersAPI.Models;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Services.ServicesComponents
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region SendMail

        public void SendMail(string[] recipients, string subject, int userId, string activationCode)
        {
            Message message = new Message(recipients, subject, userId, activationCode);

            MimeMessage mailMessage = CreateMailBody(message);
            Send(mailMessage);
        }

        #endregion

        #region PrivateMethods

        #region Send

        private void Send(MimeMessage mailMessage)
        {
            using (SmtpClient client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), false);
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        #endregion

        #region CreateMailBody

        private MimeMessage CreateMailBody(Message message)
        {
            MimeMessage mailMessage = new();
            mailMessage.From.Add(new MailboxAddress("MovieAPI", _configuration.GetValue<string>("EmailSettings:From")));
            mailMessage.To.AddRange(message.Recipients);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };

            return mailMessage;
        }

        #endregion

        #endregion
    }
}

using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UsersAPI.Models
{
    public class Message
    {
        public List<MailboxAddress> Recipients { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> recipients, string subject, int userId, string activationCode)
        {
            Recipients = new List<MailboxAddress>();
            Recipients.AddRange(recipients.Select(recipient => new MailboxAddress(null, recipient)));
            Subject = subject;
            Content = $"https://localhost:6001/register/activation?UserId={userId}&ActivationCode={activationCode}";
        }
    }
}

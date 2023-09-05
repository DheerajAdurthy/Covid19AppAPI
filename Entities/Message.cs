using System.Collections.Generic;
using System.Text;
using System.Linq;
using MimeKit;
using MailKit.Net.Smtp;

namespace Covid19ProjectAPI.Entities
{
    public class Message
    {
        public EmailConfiguration _emailConfig;
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x,_emailConfig.From)));
            Subject = subject;
            Content = content;
        }
    }
}

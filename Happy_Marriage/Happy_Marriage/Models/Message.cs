using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Happy_Marriage.Models
{
    //For Composing Email
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select( x => new MailboxAddress(x,x)));
            Subject = subject;
            Content = content;
        }
        public Message(string to,string subject,string content) { 
            To= new List<MailboxAddress>();
            Encoding UTF8 = Encoding.UTF8;
            To.Add(new MailboxAddress(UTF8,"email",to));
            Subject = subject;
            Content = content;
        }
    }
}

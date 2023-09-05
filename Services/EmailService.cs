using Covid19ProjectAPI.Entities;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;

namespace Covid19ProjectAPI.Services
{
    public class EmailService : IEmailSender
    {
        public void SendEmail(EmailSendDTO emailData)
        {
            string fromMail = "dheeraj.adurthy321@gmail.com";
            string fromPassword = "brhzihfispekfeqm";
            MailMessage message = new MailMessage();
            message.From=new MailAddress(fromMail);
            message.Subject=emailData.Subject;
            message.Body = $"<html><p>Thanks For Registering to Co-Win</p> {emailData.Body}</html>";
               
            message.To.Add(new MailAddress(emailData.To));
            message.IsBodyHtml= true;

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com") 
            { 
                Port=587,
                Credentials=new System.Net.NetworkCredential(fromMail, fromPassword),
                EnableSsl=true
            };

            smtpClient.Send(message);
        }
    }
}

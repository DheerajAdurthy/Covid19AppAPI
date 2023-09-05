using Covid19ProjectAPI.Entities;

namespace Covid19ProjectAPI.Services
{
    public interface IEmailSender
    {
        void SendEmail(EmailSendDTO emailData);
    }
}

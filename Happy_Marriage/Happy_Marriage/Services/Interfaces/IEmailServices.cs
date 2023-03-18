using Happy_Marriage.Models;

namespace Happy_Marriage.Services.Interfaces
{
    public interface IEmailServices
    {
        public bool SendEmail(EmailData data);

        //2nd try
        public void SendEmail(Message message);
    }
}

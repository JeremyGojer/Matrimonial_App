using Happy_Marriage.Models;

namespace Happy_Marriage.Services.Interfaces
{
    public interface IEmailServices
    {
        public bool SendEmail(EmailData data);
    }
}

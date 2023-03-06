using Happy_Marriage.Models;

namespace Happy_Marriage.Services.Interfaces
{
    public interface IAccountServices
    {
        public User AcceptAccount(User user);
        public User RejectAccount(User user);
        public User BanAccount(User user);
        public User UnBanAccount(User user);
    }
}

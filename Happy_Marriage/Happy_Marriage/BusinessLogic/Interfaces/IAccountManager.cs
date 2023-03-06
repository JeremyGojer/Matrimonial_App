using Happy_Marriage.Models;

namespace Happy_Marriage.BusinessLogic.Interfaces
{
    public interface IAccountManager
    {
        public User AcceptAccount(User user);
        public User RejectAccount(User user);
        public User BanAccount(User user);
        public User UnBanAccount(User user);
    }
}

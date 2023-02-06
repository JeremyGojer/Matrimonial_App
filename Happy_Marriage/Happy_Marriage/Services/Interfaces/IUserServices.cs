using Happy_Marriage.Models;

namespace Happy_Marriage.Services.Interfaces
{
    public interface IUserServices
    {
        public List<User> GetAll();

        public User Add(User user);

        public User Delete(User user);

        public User Update(User user);
        public User GetUserByEmail(string email);

        public User_Register Register(User_Register user_r);
    }
}

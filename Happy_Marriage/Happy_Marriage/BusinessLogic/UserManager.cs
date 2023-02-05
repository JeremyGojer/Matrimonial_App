using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Utilities;
using Org.BouncyCastle.Security;

namespace Happy_Marriage.BusinessLogic
{
    public class UserManager:IUserManager
    {
        private DBEntityContext dBEntityContext;
        public UserManager() {
            dBEntityContext = new DBEntityContext();
        }

        public List<User> GetAll() { 
            var list = from users in dBEntityContext.Users select users;
            return list.ToList<User>();
            
        }

        public User Add(User user) {
            dBEntityContext.Users.Add(user);
            return user;
        }

        public User Delete(User user){
            dBEntityContext.Users.Remove(user);
            return user;
        }

        public User Update(User user) { 
            dBEntityContext.Users.Update(user);
            return user;
        }

        public User GetUserByEmail(string email) {
            User user = dBEntityContext.Users.FirstOrDefault(u => u.Email == email);
            
            return user;
        }
    }
}

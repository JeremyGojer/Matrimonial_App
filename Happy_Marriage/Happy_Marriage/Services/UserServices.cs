using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;

namespace Happy_Marriage.Services
{
    public class UserServices:IUserServices
    {
        private readonly IUserManager _userManager;
        //The Reference for Constructor Dependency Injection should be Interface Type
        public UserServices(IUserManager userManager) { 
             _userManager = userManager;
        }
        
        public List<User> GetAll() => _userManager.GetAll();

        public User Add(User user) => _userManager.Add(user);

        public User Delete(User user) => _userManager.Delete(user);

        public User Update(User user) => _userManager.Update(user);

        public User GetUserByEmail(string email) => _userManager.GetUserByEmail(email);
        public User GetUserByUserId(int userid) => _userManager.GetUserByUserId(userid);
        public User GetUserByUserName(string username) => _userManager.GetUserByUserName(username);
        public bool ResetPassword(string userName, string password) => _userManager.ResetPassword(userName,password);
        public bool ChangePassword(User user, string oldpassword, string newpassword) => _userManager.ChangePassword(user, oldpassword, newpassword);
        public User_Register Register(User_Register user_r) => _userManager.Register(user_r);

        public User_Info GetUserInfo(int userid) => _userManager.GetUserInfo(userid);

        public User_Personal_Info AddPersonalInfo(User user, User_Personal_Info info) => _userManager.AddPersonalInfo(user, info);

        public User_Personal_Info GetPersonalInfo(User user) => _userManager.GetPersonalInfo(user);

        public bool IsPersonalInfoPresent(User user) => _userManager.IsPersonalInfoPresent(user);

        // Operation for User Address Info Table
        public User_Address_Info AddAddressInfo(User user, User_Address_Info info) => _userManager.AddAddressInfo(user, info);

        public List<User_Address_Info> GetAddressInfo(User user) => _userManager.GetAddressInfo(user);

        public bool IsAddressPresent(User user) => _userManager.IsAddressPresent(user);

        public List<Profile_Mini> SearchByAll(UserSearch search, User self) => _userManager.SearchByAll(search, self);
        public User_Metadata GetUserMetadata(User user) => _userManager.GetUserMetadata(user);
        public List<User> GetAllUsersCriteria(string criteria) => _userManager.GetAllUsersCriteria(criteria);
        public User_Report AddReport(User_Report report) => _userManager.AddReport(report);

    }
}

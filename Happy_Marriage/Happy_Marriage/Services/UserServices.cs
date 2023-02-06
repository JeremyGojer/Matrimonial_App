﻿using Happy_Marriage.BusinessLogic;
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

        public User_Register Register(User_Register user_r) => _userManager.Register(user_r);


    }
}

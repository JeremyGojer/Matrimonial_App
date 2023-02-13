﻿using Happy_Marriage.Models;

namespace Happy_Marriage.Services.Interfaces
{
    public interface IUserServices
    {
        public List<User> GetAll();
        public User Add(User user);
        public User Delete(User user);
        public User Update(User user);
        public User GetUserByEmail(string email);
        public User GetUserByUserId(int userid);
        public User_Register Register(User_Register user_r);
        public User_Info GetUserInfo(int userid);
        public User_Personal_Info AddPersonalInfo(User user, User_Personal_Info info);
        public User_Personal_Info GetPersonalInfo(User user);
        public bool IsPersonalInfoPresent(User user);
        public User_Address_Info AddAddressInfo(User user, User_Address_Info info);
        public List<User_Address_Info> GetAddressInfo(User user);
        public bool IsAddressPresent(User user);
        public List<Profile_Mini> SearchByAll(UserSearch search, User self);
    }
}

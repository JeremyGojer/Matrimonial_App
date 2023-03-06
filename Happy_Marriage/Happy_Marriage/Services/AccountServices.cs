﻿using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;

namespace Happy_Marriage.Services
{
    public class AccountServices: IAccountServices
    {
        private readonly IAccountManager _accountManager;
        //The Reference for Constructor Dependency Injection should be Interface Type
        public AccountServices(IAccountManager accountManager) { 
             _accountManager = accountManager;
        }

        public User AcceptAccount(User user) => _accountManager.AcceptAccount(user);
        public User RejectAccount(User user) => _accountManager.RejectAccount(user);
        public User BanAccount(User user) => _accountManager.BanAccount(user);

    }
}

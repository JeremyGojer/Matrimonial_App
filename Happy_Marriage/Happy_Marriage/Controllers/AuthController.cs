﻿using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Happy_Marriage.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserServices _userServices;

        public AuthController(ILogger<AuthController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string password) {
            User user = _userServices.GetUserByEmail(email);
            if (user != null) { 
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password, string firstname, string lastname, string contactnumber, DateTime dateofbirth, string gender, string religion) {
            User_Register user= new User_Register{UserName=username, Email=email, Password=password,
                        FirstName=firstname, LastName=lastname, ContactNumber=contactnumber,
                        Gender=gender, Religion=religion, DateOfBirth=dateofbirth
            };
            if (_userServices.GetUserByEmail(email) == null)
            {
                _userServices.Register(user);
            }
            return View();
        }
    }
}

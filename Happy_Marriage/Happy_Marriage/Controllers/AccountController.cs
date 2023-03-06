using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace Happy_Marriage.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserServices _userServices;
        private readonly IAccountServices _accountServices;

        public AccountController(ILogger<AccountController> logger, IUserServices userServices, IAccountServices accountServices)
        {
            _logger = logger;
            _userServices = userServices;
            _accountServices = accountServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminLogin([FromQuery(Name = "uid")] string uid) {
            string guid = "Jeremy";
            //http://localhost:5233/Account/AdminLogin/?uid=Jeremy
            if (uid.Equals(guid)) {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult AdminLogin(string email, string password) {
            User user = _userServices.GetUserByEmail(email);
            if (user != null && user.Password == password && user.Role == "admin") {
                string jsonuser = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("admin", jsonuser);
                TempData["action"] = "PendingForApproval";
                TempData["users"] = JsonSerializer.Serialize(new List<String>());
                TempData.Keep();
                return RedirectToAction("AdminHome", "Account");
            }
            ViewData["msg"] = "Incorrect credentials, please try again";
            
            return View();
        }
        public IActionResult AdminHome()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("admin"));
            if (user == null) { return RedirectToAction("Index", "Home"); }
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public IActionResult Users(string action) {
            TempData["action"] = action;
            TempData["users"] = JsonSerializer.Serialize(new List<User>());
            TempData.Keep();
            return PartialView();
        }
        
        [HttpPost]
        public IActionResult AcceptAccount(int userid) {
            User user = _userServices.GetUserByUserId(userid);
            if (user != null)
            {
                _accountServices.AcceptAccount(user);
            }
            return RedirectToAction("AdminHome","Account");
        }
        [HttpPost]
        public IActionResult RejectAccount(int userid)
        {
            User user = _userServices.GetUserByUserId(userid);
            if (user != null)
            {
                _accountServices.RejectAccount(user);
            }
            return RedirectToAction("AdminHome", "Account");
        }
        [HttpPost]
        public IActionResult BanAccount(int userid)
        {
            User user = _userServices.GetUserByUserId(userid);
            if (user != null)
            {
                _accountServices.BanAccount(user);
            }
            return RedirectToAction("AdminHome", "Account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
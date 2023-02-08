﻿using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Happy_Marriage.Controllers
{
    public class ProfilePageController : Controller
    {
        private readonly ILogger<ProfilePageController> _logger;
        private readonly IUserServices _userServices;

        public ProfilePageController(ILogger<ProfilePageController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        public IActionResult MyProfile()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            User_Info userinfo = _userServices.GetUserInfo(user.UserId);
            User_Personal_Info upi = _userServices.GetPersonalInfo(user);
            List<User_Address_Info> listuai = _userServices.GetAddressInfo(user);
            ViewData["user"] = user;
            ViewData["userinfo"] = userinfo;
            ViewData["upi"] = upi;
            ViewData["listuai"] = listuai;
            return View();
        }

        public IActionResult Index() {
            return View();
        }
        
        public IActionResult PersonalInfo()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            
            return PartialView();
        }
        public IActionResult AddressInfo()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            
            return PartialView();
        }

        [HttpPost]
        public IActionResult Search(int minage=18, int maxage=100, string gender="default", string education="default", string city="default") {
            UserSearch search = new UserSearch{ MinAge = minage,
                                                MaxAge = maxage,
                                                Gender = gender,
                                                City = city,
                                                Education= education
            };
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            List<Profile_Mini> pmini = _userServices.SearchByAll(search, user);
            ViewData["pmini"] = pmini;
            return RedirectToAction("Index","ProfilePage");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
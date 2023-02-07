using Happy_Marriage.Models;
using Happy_Marriage.Services;
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

        public IActionResult Index()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            User_Info userinfo = _userServices.GetUserInfo(user.UserId);
            ViewData["user"] = user;
            ViewData["userinfo"] = userinfo;
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Happy_Marriage.Models;
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
        public IActionResult Register(string username, string email, string password) {
            
            
            return View();
        }
    }
}

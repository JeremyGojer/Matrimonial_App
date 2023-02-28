using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Text.Json;

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
            if (user != null && user.Password == password) {
                //Redirect to landing page
                string jsonuser = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("user",jsonuser);
                return RedirectToAction("Index", "ProfilePage");
            }
            //Back to login form
            ViewData["msg"] = "Incorrect credentials, please try again";
            return View();
        }

        public IActionResult LogOut() { 
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index","Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password, string firstname, string lastname, string contactnumber, DateTime dateofbirth,string job, string gender, string religion, string education) {
            if(gender == null) { gender="Male"; }
            User_Register user= new User_Register{UserName=username, Email=email, Password=password,
                        FirstName=firstname, LastName=lastname, ContactNumber=contactnumber, Job=job,
                        Education=education ,Gender=gender, Religion=religion, DateOfBirth=dateofbirth
            };
            if (_userServices.GetUserByEmail(email) == null)
            {
                _userServices.Register(user);
                return RedirectToAction("Success","Home");
            }
            ViewData["msg"] = "Something went wrong, please check details again";
            return View();
        }

        public IActionResult PersonalDetailsForm() {
            ViewData["msg"] = "";
            return View();
        }
        [HttpPost]
        public IActionResult PersonalDetailsForm(User_Personal_Info pinfo)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            if (pinfo != null) {
                _userServices.AddPersonalInfo(user,pinfo);
                return RedirectToAction("MyProfile","ProfilePage");
            }
            ViewData["msg"] = "An Error Occured, Please Try Again";
            return View();
        }

        public IActionResult AddressDetailsForm() {
            ViewData["msg"] = "";
            ViewData["countries"] = null;
            return View();
        }
        [HttpPost]
        public IActionResult AddressDetailsForm(User_Address_Info ainfo) {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            if (ainfo != null)
            {
                _userServices.AddAddressInfo(user, ainfo);
                return RedirectToAction("MyProfile", "ProfilePage");
            }
            ViewData["msg"] = "An Error Occured, Please Try Again";
            return View();
        }

    }
}

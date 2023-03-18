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
        private readonly IEmailServices _email;

        public AuthController(ILogger<AuthController> logger, IUserServices userServices, IEmailServices email)
        {
            _logger = logger;
            _userServices = userServices;
            _email = email;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password) {
            User user = _userServices.GetUserByEmail(email);
            if (user != null && user.Password == password && user.ApprovalStatus == "Approved")
            {
                //Redirect to landing page
                string jsonuser = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("user", jsonuser);
                return RedirectToAction("Index", "ProfilePage");
            }
            else if (user != null && user.Password == password && user.ApprovalStatus == "Not Approved")
            {
                ViewData["msg"] = "Your Account is pending for approval";
            }
            else if (user != null && user.Password == password && user.ApprovalStatus == "Rejected")
            {
                ViewData["msg"] = "Your Last Appication was rejected , Please contact admin";
            }
            else {
                ViewData["msg"] = "Incorrect credentials, please try again";
            }
            //Back to login form

            return View();
        }

        public IActionResult LogOut() {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password, string firstname, string lastname, string contactnumber, DateTime dateofbirth, string job, string gender, string religion, string education) {
            if (gender == null) { gender = "Male"; }
            User_Register user = new User_Register { UserName = username, Email = email, Password = password,
                FirstName = firstname, LastName = lastname, ContactNumber = contactnumber, Job = job,
                Education = education, Gender = gender, Religion = religion, DateOfBirth = dateofbirth
            };
            if (_userServices.GetUserByEmail(email) == null)
            {
                _userServices.Register(user);
                return RedirectToAction("Success", "Home");
            }
            ViewData["msg"] = "Something went wrong, please check details again";
            return View();
        }

        public IActionResult ForgotPassword() {
            ViewData["msg"] = "";
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            User user = _userServices.GetUserByEmail(email);
            if (user != null)
            {

                string guid = Guid.NewGuid().ToString();
                string uid = "ResetMyPass";
                string url = "http://localhost:5233/Auth/PasswordResetLink?username=" + user.UserName + "&uid=" + guid;
                string resetstring = user.UserName + "-" + guid;
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                //Send a url link via Email
                //Console.WriteLine(url);
                /*_email.SendEmail(new EmailData { EmailToId=user.Email,
                                                 EmailToName=user.UserName,
                                                 EmailSubject="Your link for password reset",
                                                 EmailBody="Your link is "+url});*/
                _email.SendEmail(new Message(user.Email,"Password Recovery", url));
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                string strresetsessions = HttpContext.Session.GetString("PasswordResetLinkSessions");
                List<string> resetsessions = null;
                if (strresetsessions == null)
                {
                    resetsessions = new List<string>();
                }
                else {
                    resetsessions = JsonSerializer.Deserialize<List<string>>(strresetsessions);
                }
                resetsessions.Add(resetstring);

                HttpContext.Session.SetString("PasswordResetLinkSessions", JsonSerializer.Serialize(resetsessions));
                ViewData["msg"] = "Email for resetting password sent to " + user.Email;
            }
            else {
                ViewData["msg"] = "Email mentioned " + email + " is not registered with us. Please contact admin";
            }

            return View();
        }

        [HttpGet]
        public IActionResult PasswordResetLink([FromQuery(Name = "uid")] string uid, [FromQuery(Name = "username")] string username) {
            string resetstring = username + "-" + uid;

            string list = HttpContext.Session.GetString("PasswordResetLinkSessions");
            List<string> resetstrings = null;
            if (list != null)
            {
                resetstrings = JsonSerializer.Deserialize<List<string>>(list);

                foreach (var str in resetstrings)
                {

                    if (str.Equals(resetstring))
                    {
                        ViewData["user"] = _userServices.GetUserByUserName(username);
                        ViewData["uid"] = uid;
                        return View();
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult PasswordResetLink(string username, string password, string uid) {
            _userServices.ResetPassword(username, password);
            return RedirectToAction("Index", "Home");
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
                _userServices.AddPersonalInfo(user, pinfo);
                return RedirectToAction("MyProfile", "ProfilePage");
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

        public IActionResult ChangePassword() {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            ViewData["msg"] = "";
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string oldpassword, string newpassword) {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            bool status = _userServices.ChangePassword(user, oldpassword, newpassword);
            if (status) {
                //Change password in session too
                user.Password = newpassword;
                HttpContext.Session.SetString("user", JsonSerializer.Serialize(user));
                return RedirectToAction("MyProfile", "ProfilePage");
            }
            ViewData["msg"] = "Old Password doesnt match";
            return View();
        }

    }
}

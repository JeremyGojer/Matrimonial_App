using Happy_Marriage.Models;
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
        private readonly IFileServices _fileServices;

        public ProfilePageController(ILogger<ProfilePageController> logger, IUserServices userServices, IFileServices fileServices)
        {
            _logger = logger;
            _userServices = userServices;
            _fileServices = fileServices;
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

        public IActionResult Index()
        {
            List<Profile_Mini> pmini = TempData["pmini"] as List<Profile_Mini>;
            ViewData["pmini"] = pmini;
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

        public IActionResult Search() {
            return View();
        }

        [HttpPost]
        public IActionResult Search(int minage = 18, int maxage = 100, string gender = "default", string education = "All", string city = "All")
        {
            UserSearch search = new UserSearch
            {
                MinAge = minage,
                MaxAge = maxage,
                Gender = gender,
                City = city,
                Education = education
            };
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            List<Profile_Mini> pmini = _userServices.SearchByAll(search, user);
            TempData["pmini"] =  JsonSerializer.Serialize(pmini);
            return RedirectToAction("Index", "ProfilePage");
        }

        public IActionResult SearchResult()
        {
            TempData.Keep("pmini");
            return View();
        }

        public IActionResult MyUploads()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            List<User_Upload> imglist = _fileServices.AllUserImagesUrl(user);
            ViewData["imglist"] = imglist;
            return View();
        }
        [HttpPost]
        public IActionResult MyUploads(UploaderModel uploaderModel)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            if (ModelState.IsValid)
            {
                if (uploaderModel.File != null)
                {
                    //set folder here
                    string folder = "wwwroot/User_Uploads/";
                    
                    //set file name here < UserName + Random Identifier + ActualFileName
                    folder += user.UserName + Guid.NewGuid().ToString() + ".jpg";

                    uploaderModel.File.CopyTo(new FileStream(folder, FileMode.Create));
                    //Add the entry of image added to the database with its url
                    _fileServices.Upload(new User_Upload {UserId = user.UserId,
                                                          ImageUrl = folder.Substring(7),
                                                          ReceivedOn= DateTime.Now,
                                                          });
                    ViewData["msg"] = "Photo added sucessfully";
                    return RedirectToAction("Index", "ProfilePage");
                }
            }
            ViewData["msg"] = "Something went wrong, Please check your photo";
            

            return View();
        }

        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
﻿using Happy_Marriage.Exceptions;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Happy_Marriage.Controllers
{
    public class ProfilePageController : Controller
    {
        private readonly ILogger<ProfilePageController> _logger;
        private readonly IUserServices _userServices;
        private readonly IFileServices _fileServices;
        private readonly IRelationshipServices _relationships;

        public ProfilePageController(ILogger<ProfilePageController> logger, IUserServices userServices, IFileServices fileServices, IRelationshipServices relationship)
        {
            _logger = logger;
            _userServices = userServices;
            _fileServices = fileServices;
            _relationships = relationship;
        }
        public User GetUserFromSession()
        {
            User user = null;
            try {
                
                string usrstr = HttpContext.Session.GetString("user");
                if (usrstr != null)
                    user = JsonSerializer.Deserialize<User>(usrstr);
                return user;
            }
            catch (Exception e) {
                SessionExpiryLogout();
                return null;
            }
            
        }
        public IActionResult SessionExpiryLogout() { 
            return RedirectToAction("Login","Auth");
        }
        public IActionResult MyProfile()
        {
            User user = GetUserFromSession();
            /*User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }*/
            User_Info userinfo = _userServices.GetUserInfo(user.UserId);
            User_Personal_Info upi = _userServices.GetPersonalInfo(user);
            List<User_Address_Info> listuai = _userServices.GetAddressInfo(user);
            User_Metadata metadata = _userServices.GetUserMetadata(user);
            ViewData["user"] = user;
            ViewData["userinfo"] = userinfo;
            ViewData["upi"] = upi;
            ViewData["listuai"] = listuai;
            ViewData["metadata"] = metadata;
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

        //Code for search section /////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult SearchMenu()
        {
            List<Profile_Mini> pmini = TempData["pmini"] as List<Profile_Mini>;
            ViewData["pmini"] = pmini;
            return View();
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
            return RedirectToAction("SearchMenu", "ProfilePage");
        }

        public IActionResult SearchResult()
        {
            TempData.Keep("pmini");
            return View();
        }
        [HttpPost]
        public IActionResult OthersProfile(int userid) {
            User user = _userServices.GetUserByUserId(userid);
            User_Info userinfo = _userServices.GetUserInfo(user.UserId);
            User_Personal_Info upi = _userServices.GetPersonalInfo(user);
            List<User_Address_Info> listuai = _userServices.GetAddressInfo(user);
            User_Metadata metadata = _userServices.GetUserMetadata(user);
            ViewData["user"] = user;
            ViewData["userinfo"] = userinfo;
            ViewData["upi"] = upi;
            ViewData["listuai"] = listuai;
            ViewData["metadata"] = metadata;
            return View();
        }
        [HttpPost]
        public IActionResult SendRequest(int userid) {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            _relationships.SendRequest(user.UserId,userid);
            return RedirectToAction("Index","ProfilePage");
        }
        //Code for requests and relations section //////////////////////////////////////////////////////////

        public IActionResult MyRequests()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            //Get All requests related to this user
            ViewData["receivedrequests"] =  _relationships.AllReceivedRequests(user);
            ViewData["sentrequests"] = _relationships.AllSentRequests(user);
            return View();
        }
        [HttpPost]
        public IActionResult AcceptRequest(int userid) 
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            //Session user is the receiver here
            Console.WriteLine(user.UserId+"-"+userid);
            _relationships.AcceptRequest(userid, user.UserId);
            return RedirectToAction("MyRequests", "ProfilePage");
        }
        [HttpPost]
        public IActionResult DeclineRequest(int userid)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            //Session user is the receiver here
            _relationships.RejectRequest(userid, user.UserId);
            return RedirectToAction("MyRequests", "ProfilePage");
        }
        [HttpPost]
        public IActionResult CancelRequest(int userid)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            //Session user is the sender here
            _relationships.CancelRequest(user.UserId,userid);
            return RedirectToAction("MyRequests", "ProfilePage");
        }
        public IActionResult MyConnections() {
            User user = GetUserFromSession();
            ViewData["MyConnections"] = _relationships.GetAllConnectionsOfUser(user);
            return View();
        }
        public IActionResult GenerateReport(int userid) {
            User user = GetUserFromSession();
            ViewData["msg"] = "";
            ViewData["ReportedOn"] = userid;
            ViewData["ReportedBy"] = user.UserId;
            return View();
        }
        [HttpPost]
        public IActionResult GenerateReport(User_Report report) {
            report.CreatedOn = DateTime.Now;
            _userServices.AddReport(report);
            ViewData["msg"] = "reported sucessfully";
            ViewData["ReportedOn"] = report.ReportedOn;
            ViewData["ReportedBy"] = report.ReportedBy;
            return View();
        }
        [HttpPost]
        public IActionResult RemoveConnection(int userid)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }

            _relationships.RemoveAMutualConnection(userid, user.UserId);
            return RedirectToAction("MyConnections", "ProfilePage");
        }

        //Code for uploads section /////////////////////////////////////////////////////////////////////////

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
                    
                    //set file name here < UserName + Random Identifier + Extension(.jpg)
                    folder += user.UserName + Guid.NewGuid().ToString() + ".jpg";

                    uploaderModel.File.CopyTo(new FileStream(folder, FileMode.Create));
                    //Add the entry of image added to the database with its url
                    _fileServices.Upload(new User_Upload {UserId = user.UserId,
                                                          ImageUrl = folder.Substring(7),
                                                          ReceivedOn= DateTime.Now,
                                                          });
                    ViewData["msg"] = "Photo added sucessfully";

                    //return RedirectToAction("Index", "ProfilePage");
                    return View();
                }
            }
            ViewData["msg"] = "Something went wrong, Please check your photo";
            

            return View();
        }

        public IActionResult Gallery()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            List<User_Upload> imglist = _fileServices.AllUserImagesUrl(user);
            TempData["imglist"] = JsonSerializer.Serialize(imglist);
            return View();
        }

        [HttpPost]
        public IActionResult SetAsProfilePhoto(string imgurl) 
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            //Also change the user profile pic in session
            user.ImageUrl = imgurl;
            HttpContext.Session.SetString("user", JsonSerializer.Serialize(user));
            _fileServices.SetAsProfilePicture(imgurl,user);
            return RedirectToAction("Index","ProfilePage");
        }

        [HttpGet]
        public IActionResult ImageDetails([FromQuery(Name ="img")] string imgurl) {
           
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            
            ViewData["imgurl"] = imgurl;
            return View();
        }
        [HttpPost]
        public IActionResult SetAsCoverPhoto(string imgurl)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            _fileServices.SetAsCoverPicture(imgurl, user);
            return RedirectToAction("Index", "ProfilePage");
        }

        [HttpPost]
        public IActionResult DeleteFromUploads(string imgurl)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            bool status = _fileServices.DeletePicture(imgurl, user);
            if (!status) {
                ViewData["msg"] = "Unable to delete image";
                return RedirectToAction("Index", "ProfilePage");
            }
            // Set the image in session if changed
            HttpContext.Session.SetString("user", JsonSerializer.Serialize(user));

            return RedirectToAction("Index", "ProfilePage");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
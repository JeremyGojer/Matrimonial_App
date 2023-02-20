using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Happy_Marriage.Controllers
{
    public class MessengerController : Controller
    {
        private readonly ILogger<MessengerController> _logger;
        private readonly IMessengerServices _messengerServices;
        private readonly IRelationshipServices _relationships;

        public MessengerController(ILogger<MessengerController> logger, IMessengerServices messengerServices, IRelationshipServices relationships)
        {
            _logger = logger;
            _messengerServices = messengerServices;
            _relationships = relationships;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Messenger","Messenger");
        }

        public IActionResult Messenger()
        {
            TempData.Keep();
            return View();
        }
        public IActionResult MyMessenger()
        {
            TempData.Keep();
            return View();
        }

        public IActionResult MyConnectionsForMsg()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            List<Profile_Mini> conn = _relationships.GetAllConnectionsOfUser(user);
            ViewData["MyConnections"] = JsonSerializer.Serialize(conn);
            return PartialView();
        }
        public IActionResult ChatBox()
        {

            return PartialView();
        }
        [HttpPost]
        public IActionResult ChatBox(int userid)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            //Due for optimisation
            //TempData["SentMsgs"] = _messengerServices.ShowUserSentMessagesForChat(user.UserId, userid);
            //TempData["ReceivedMsgs"] = _messengerServices.ShowUserReceivedMessagesForChat(user.UserId, userid);
            ViewData["ChatMsgs"] = _messengerServices.ShowUserMessagesForChat(user.UserId, userid);
            ViewData["sender"] = user.UserId;
            return PartialView();
        }
        [HttpPost]
        public IActionResult SendMessage(string content,int userid)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            User_Messages msg = new User_Messages { UserId1 = user.UserId, 
                                                    UserId2 = userid,
                                                    Content = content,
                                                    ReceivedOn = DateTime.Now,
                                                    Status = "delivered"};
            _messengerServices.AddAMessage(msg);
            return RedirectToAction("MyMessenger","Messenger");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
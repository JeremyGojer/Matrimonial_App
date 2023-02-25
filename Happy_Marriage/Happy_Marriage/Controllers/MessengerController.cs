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
            
            return View();
        }
        public IActionResult MyMessenger()
        {
            
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            List<Profile_Mini> conn = _relationships.GetAllConnectionsOfUser(user);
            TempData["MyConnections"] = JsonSerializer.Serialize(conn);
            // Set userid if clicked on the user from the menu otherwise 0
            if (TempData["user_id"] == null)
            {
                TempData["user_id"] = 0;
            }
            string Id = TempData["user_id"].ToString();
            //Console.WriteLine(Id);
            int userid = 0;
            if (Id != null) {
                userid = int.Parse(Id);
            }
            var chatmsgs = _messengerServices.ShowUserMessagesForChat(user.UserId, userid);
            TempData["ChatMsgs"] = JsonSerializer.Serialize(chatmsgs);
            TempData["sender"] = user.UserId.ToString();

            return View();
        }

        public IActionResult MyConnectionsForMsg()
        {
            TempData.Keep();
            return PartialView();
        }
        public IActionResult ChatBox()
        {
            Console.WriteLine("In get of chatbox");
            TempData.Keep();
            return PartialView();
        }
        [HttpPost]
        public IActionResult ChatBox(int userid)
        {
            Console.WriteLine("In post of chatbox");
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            var chatmsgs = _messengerServices.ShowUserMessagesForChat(user.UserId, userid);
            TempData["ChatMsgs"] = JsonSerializer.Serialize(chatmsgs);
            TempData["user_id"] = userid.ToString();
            TempData.Keep();
            return RedirectToAction("MyMessenger","Messenger");
        }
        public IActionResult SendMessage() {
            TempData.Keep();
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(string textcontent,int userid)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
            if (user == null) { return RedirectToAction("Login", "Auth"); }
            User_Messages msg = new User_Messages { UserId1 = user.UserId, 
                                                    UserId2 = userid,
                                                    Content = textcontent,
                                                    ReceivedOn = DateTime.Now,
                                                    Status = "delivered"};
            _messengerServices.AddAMessage(msg);
            TempData["user_id"] = userid;
            return RedirectToAction("MyMessenger","Messenger");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
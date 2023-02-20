using Happy_Marriage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Happy_Marriage.Controllers
{
    public class MessengerController : Controller
    {
        private readonly ILogger<MessengerController> _logger;

        public MessengerController(ILogger<MessengerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Messenger","Messenger");
        }

        public IActionResult Messenger()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
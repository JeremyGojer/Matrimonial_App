using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Happy_Marriage.Controllers
{
    [Route("AddressApi")]
    [ApiController]
    public class AddressApiController : Controller
    {
        private readonly ILogger<AddressApiController> _logger;
        private readonly IAjaxServices _ajaxServices;

        public AddressApiController(ILogger<AddressApiController> logger, IAjaxServices ajaxServices)
        {
            _logger = logger;
            _ajaxServices = ajaxServices;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Success", "Home");
        }
        [Route("Countries")]
        public JsonResult Countries() {
            List<string> countries = _ajaxServices.GetAllCountries();
            return new JsonResult(Ok(countries));
        }
        [Route("States")]
        [HttpPost]
        public JsonResult States(string country)
        {
            
            List<string> states = _ajaxServices.GetStatesFromCountry(country);
            return new JsonResult(Ok(states));
        }
        [Route("Districts")]
        [HttpPost]
        public JsonResult Districts(string state)
        {
            List<string> district = _ajaxServices.GetDistrictsFromState(state);
            return new JsonResult(Ok(district));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
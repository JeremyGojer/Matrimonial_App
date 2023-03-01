using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Happy_Marriage.Controllers
{
    [Route("AddressApi/")]
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

        [HttpGet("Countries")]
        public JsonResult Countries() {
            List<string> countries = _ajaxServices.GetAllCountries();
            return new JsonResult(Ok(countries));
        }

        [HttpPost("States")]
        public JsonResult States(ApiString country)
        {
            string? cs = country.Name;         
            List<string> states = _ajaxServices.GetStatesFromCountry(cs);
            return new JsonResult(Ok(states));
        }
        
        [HttpPost("Districts")]
        public JsonResult Districts(ApiString state)
        {
            string? cs = state.Name;
            List<string> district = _ajaxServices.GetDistrictsFromState(cs);
            return new JsonResult(Ok(district));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
﻿using Happy_Marriage.Models;
using Happy_Marriage.Services;
using Happy_Marriage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Happy_Marriage.Controllers
{
    [Route("Api/")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IAjaxServices _ajaxServices;
        private readonly IUserServices _userServices;
        private readonly IAccountServices _account;

        public ApiController(ILogger<ApiController> logger, IAjaxServices ajaxServices, IUserServices userServices, IAccountServices account)
        {
            _logger = logger;
            _ajaxServices = ajaxServices;
            _userServices = userServices;
            _account = account;
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
        [HttpGet("CheckAdmin")]
        public JsonResult CheckAdmin() 
        {
            List<string> admins = _userServices.AdminList();
            return new JsonResult(Ok(admins));
        }

        [HttpGet("AllUsers")]
        public JsonResult AllUsers()
        {
            List<User> users = _userServices.GetAll();

            return new JsonResult(Ok(users));
        }
        [HttpGet("PendingForApprovalUsers")]
        public JsonResult PendingForApproval()
        {
            List<User> users = _userServices.GetAllUsersCriteria("Not Approved");

            return new JsonResult(Ok(users));
        }
        [HttpGet("RejectedUsers")]
        public JsonResult RejectedUsers()
        {
            List<User> users = _userServices.GetAllUsersCriteria("Rejected");

            return new JsonResult(Ok(users));
        }
        [HttpGet("BannedUsers")]
        public JsonResult BannedUsers()
        {
            List<User> users = _userServices.GetAllUsersCriteria("Banned");

            return new JsonResult(Ok(users));
        }
        [HttpGet("Reports")]
        public JsonResult Reports()
        {
            List<ReportView> reports = _account.ViewReportData();

            return new JsonResult(Ok(reports));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;

namespace Happy_Marriage.Services
{
    public class AccountServices: IAccountServices
    {
        private readonly IAccountManager _accountManager;
        //The Reference for Constructor Dependency Injection should be Interface Type
        public AccountServices(IAccountManager accountManager) { 
             _accountManager = accountManager;
        }

        public User AcceptAccount(User user) => _accountManager.AcceptAccount(user);
        public User RejectAccount(User user) => _accountManager.RejectAccount(user);
        public User BanAccount(User user) => _accountManager.BanAccount(user);
        public User UnBanAccount(User user) => _accountManager.UnBanAccount(user);
        public bool CreateReport(User_Report report) => _accountManager.CreateReport(report);
        public List<User_Report> FindReportsForUser(User user) => _accountManager.FindReportsForUser(user);
        public List<User_Report> FindReportsForUser(int userid) => _accountManager.FindReportsForUser(userid);
        public List<ReportView> ViewReportData() => _accountManager.ViewReportData() ;

    }
}

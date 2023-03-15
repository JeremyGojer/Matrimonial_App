using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Utilities;

namespace Happy_Marriage.BusinessLogic
{

    public class AccountManager : IAccountManager
    {
        private readonly DBEntityContext dBEntityContext;
        public AccountManager(DBEntityContext dBEntityContext)
        {
            this.dBEntityContext = dBEntityContext;
        }

        public User AcceptAccount(User user)
        {
            user.ApprovalStatus = "Accepted";
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();
            return user;
        }

        public User RejectAccount(User user)
        {
            user.ApprovalStatus = "Rejected";
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();
            return user;
        }

        public User BanAccount(User user)
        {
            user.ApprovalStatus = "Banned";
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();
            return user;
        }

        public User UnBanAccount(User user)
        {
            user.ApprovalStatus = "Approved";
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();
            return user;
        }

        public bool CreateReport(User_Report report)
        {
            bool status = false;

            dBEntityContext.Users_Reports.Add(report);
            dBEntityContext.SaveChanges();
            status = true;

            return status;
        }

        public List<User_Report> FindReportsForUser(User user)
        {
            var reports = from report in dBEntityContext.Users_Reports where (user.UserId == report.ReportedOn) select report;
            return reports.ToList();
        }
        public List<User_Report> FindReportsForUser(int userid)
        {
            var reports = from report in dBEntityContext.Users_Reports where (userid == report.ReportedOn) select report;
            return reports.ToList();
        }
        public List<ReportView> ViewReportData() {
            var reports = from report in dBEntityContext.Users_Reports
                          join names in dBEntityContext.Users on report.ReportedOn equals names.UserId
                          group report by new { names.UserName , report.ReportedOn} into count
                          select new ReportView { UserId=count.Key.ReportedOn,
                                                  UserName=count.Key.UserName,
                                                  ReportCount=count.Count()};
            return reports.ToList();
        }

        public List<User_Report> AllReports() 
        { 
            var reports = from report in dBEntityContext.Users_Reports select report;
            return reports.ToList();
        }

    }


}

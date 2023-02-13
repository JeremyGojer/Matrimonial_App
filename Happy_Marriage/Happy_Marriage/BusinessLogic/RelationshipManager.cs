using Google.Protobuf.WellKnownTypes;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Utilities;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Security;

namespace Happy_Marriage.BusinessLogic
{
    public class RelationshipManager:IRelationshipManager
    {
        private readonly DBEntityContext dBEntityContext;
        public RelationshipManager(DBEntityContext dBEntityContext) {
            this.dBEntityContext = dBEntityContext;
        }

        public bool SendRequest(int userid1, int userid2) {
            bool status = false;
            User_Request user_request = new User_Request { UserId1 = userid1,
                                                           UserId2 = userid2,
                                                           CreatedOn = DateTime.Now};
            dBEntityContext.Users_Requests.Add(user_request);
            dBEntityContext.SaveChanges();
            status = true;

            return status;
        }

        public bool AcceptRequest(int userid1, int userid2) {
            bool status = false;
            User_Request user_request = new User_Request
            {
                UserId1 = userid1,
                UserId2 = userid2,
            };
            dBEntityContext.Users_Requests.Remove(user_request);
            dBEntityContext.SaveChanges();
            status = true;

            return status;
        }

        public bool RejectRequest(int userid1, int userid2)
        {
            bool status = false;
            User_Request user_request = new User_Request
            {
                UserId1 = userid1,
                UserId2 = userid2,
            };
            dBEntityContext.Users_Requests.Remove(user_request);
            dBEntityContext.SaveChanges();
            status = true;

            return status;
        }
        public bool CancelRequest(int userid1, int userid2)
        {
            bool status = false;
            User_Request user_request = new User_Request
            {
                UserId1 = userid1,
                UserId2 = userid2,
            };
            dBEntityContext.Users_Requests.Remove(user_request);
            dBEntityContext.SaveChanges();
            status = true;

            return status;
        }

        public static int FindAgeFromDateTime(DateTime dob)
        {
            DateTime today = DateTime.Now;
            int age = 0;
            if (today.Month > dob.Month)
            {
                age = today.Year - dob.Year;
            }
            else if (today.Month == dob.Month && today.Day > dob.Day)
            {
                age = today.Year - dob.Year;
            }
            else
            {
                age = today.Year - dob.Year - 1;
            }

            return age;
        }
        public List<Profile_Mini> AllReceivedRequests(User userip) {
            var list = from users in dBEntityContext.Users_Requests 
                       join user in dBEntityContext.Users 
                       on users.UserId1 equals user.UserId
                       join useri in dBEntityContext.Users_Info
                       on users.UserId1 equals useri.UserId
                       where users.UserId2 == userip.UserId select new Profile_Mini 
                       {
                           UserName = user.UserName,
                           ImageUrl = user.ImageUrl,
                           Age = FindAgeFromDateTime(useri.DateOfBirth),
                           Job = useri.Job
                       };
            
            return list.ToList();
        }
        public List<Profile_Mini> AllSentRequests(User userip)
        {
            var list = from users in dBEntityContext.Users_Requests
                       join user in dBEntityContext.Users
                       on users.UserId2 equals user.UserId
                       join useri in dBEntityContext.Users_Info
                       on users.UserId2 equals useri.UserId
                       where users.UserId1 == userip.UserId
                       select new Profile_Mini
                       {
                           UserName = user.UserName,
                           ImageUrl = user.ImageUrl,
                           Age = FindAgeFromDateTime(useri.DateOfBirth),
                           Job = useri.Job
                       };

            return list.ToList();
        }

        public bool IfRequestSent(int userid1, int userid2)
        {
            bool status = false;
            var list1 = from users in dBEntityContext.Users_Requests where (users.UserId1 == userid1 && users.UserId2 == userid2) select users;

            return list1.Any();
        }

        public bool IfRequestReceived(int userid1, int userid2)
        {
            bool status = false;
            var list1 = from users in dBEntityContext.Users_Requests where (users.UserId2 == userid1 && users.UserId1 == userid2) select users;

            return list1.Any();
        }

    }

    
}

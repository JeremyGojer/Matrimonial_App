﻿using Google.Protobuf.WellKnownTypes;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Utilities;
using Happy_Marriage.Utilities.Interfaces;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Mysqlx.Session;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Security;

namespace Happy_Marriage.BusinessLogic
{
    // Manages both User and User_Info TABLES
    public class UserManager:IUserManager
    {
        private readonly DBEntityContext dBEntityContext;
        
        public UserManager(DBEntityContext dBEntityContext)
        {
            this.dBEntityContext = dBEntityContext;
            
        }

        public List<User> GetAll() { 
            var list = from users in dBEntityContext.Users select users;
            return list.ToList<User>();   
        }

        public User Add(User user) {
            dBEntityContext.Users.Add(user);
            dBEntityContext.SaveChanges();
            return user;
        }

        public User Delete(User user){
            dBEntityContext.Users.Remove(user);
            dBEntityContext.SaveChanges() ;
            return user;
        }

        public User Update(User user) { 
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();
            return user;
        }

        public User GetUserByEmail(string email) {
            var list = from users in dBEntityContext.Users where users.Email == email select users;
            User user = list.FirstOrDefault(u => u.Email == email);
            
            return user;
        }

        public User GetUserByUserId(int userid) {
            var list = from users in dBEntityContext.Users where users.UserId == userid select users;
            User user = list.FirstOrDefault(u => u.UserId == userid);
            return user;
        }

        public User GetUserByUserName(string username) {
            var list = from users in dBEntityContext.Users where users.UserName == username select users;
            User user = list.FirstOrDefault(u => u.UserName == username);
            return user;
        }

        public User_Register Register(User_Register user_r) {
            User user = new User { 
                                   UserName = user_r.UserName,
                                   Email = user_r.Email,
                                   Password = user_r.Password,
                                   ContactNumber = user_r.ContactNumber,
                                   Role = "user",
                                   JoinedOn = DateTime.Now,
                                   ImageUrl = "/images/Default_Profile_Pic.jpg"
            };

            //Insert data in Users table
            Add(user);
            //After setting the data to the table, retrieve back to get id generated by MySql for the table and then set it to the second table
            //Two save changes dont work in same scope only the first one works, So the function call
            user = GetUserByEmail(user_r.Email);
            User_Info user_Info = new User_Info { UserId=user.UserId,
                                                  FirstName=user_r.FirstName,
                                                  LastName=user_r.LastName,
                                                  Gender= user_r.Gender,
                                                  DateOfBirth=user_r.DateOfBirth,
                                                  Job=user_r.Job,
                                                  Education=user_r.Education,
                                                  Religion=user_r.Religion
                                                };
            //Insert data in Users_Info Table
            dBEntityContext.Users_Info.Add(user_Info);
            dBEntityContext.SaveChanges();

            return user_r;
        }

        public bool ResetPassword(string userName, string password)
        {
            bool status = false;

            User user = GetUserByUserName(userName);
            user.Password = password;
            User user1 = Update(user);
            if (user1 != null) status = true;

            return status;
        }

        public User_Info GetUserInfo(int userid) {
            var list = from user in dBEntityContext.Users_Info where user.UserId == userid select user;
            User_Info userinfo = list.FirstOrDefault(u => u.UserId == userid);
            return userinfo;
        }
        // About User Personal Info is here //////////////////////////////////////////////////////////////////////////
        public User_Personal_Info AddPersonalInfo(User user, User_Personal_Info info) { 
            
            int userid = user.UserId;
            User_Personal_Info upi = new User_Personal_Info {UserId = userid,
                                                             Height = info.Height,
                                                             Weight = info.Weight,
                                                             FoodType = info.FoodType,
                                                             Smoking = info.Smoking,
                                                             Alcohol = info.Alcohol,
                                                             BloodGroup = info.BloodGroup,
                                                             MartialStatus = info.MartialStatus,
                                                             AnnualIncome = info.AnnualIncome
            };
            dBEntityContext.Users_Personal_Info.Add(upi);
            dBEntityContext.SaveChanges();

            return upi;
        }

        public User_Personal_Info GetPersonalInfo(User user) {
            var list = from useri in dBEntityContext.Users_Personal_Info where (useri.UserId == user.UserId) select useri;
            User_Personal_Info upi = list.FirstOrDefault<User_Personal_Info>(); 
            return upi;
        }

        public bool IsPersonalInfoPresent(User user) {
            bool status = false;

            if (GetPersonalInfo(user) != null) {
                status = true;
            }

            return status;
        }

        // About user address info is here  ////////////////////////////////////////////////////////////////////////////
        public User_Address_Info AddAddressInfo(User user, User_Address_Info info) {

            int userid = user.UserId;
            User_Address_Info uai = new User_Address_Info {UserId = userid,
                                                           Country = info.Country,
                                                           State = info.State,
                                                           District = info.District,
                                                           City = info.City,
                                                           PinCode= info.PinCode,
                                                           AddressLine2 = info.AddressLine2,
                                                           AddressLine1= info.AddressLine1
            };
            dBEntityContext.Users_Address_Info.Add(uai);
            dBEntityContext.SaveChanges();

            return uai;
        }

        public List<User_Address_Info> GetAddressInfo(User user)
        {
            var list = from useri in dBEntityContext.Users_Address_Info where (useri.UserId == user.UserId) select useri;
            return list.ToList();
        }

        public bool IsAddressPresent(User user)
        {
            bool status = false;

            if (GetAddressInfo(user) != null)
            {
                status = true;
            }

            return status;
        }

        // User Search Methods  ////////////////////////////////////////////////////////////

        //  Takes join from three tables and returns a mini profile of users matching the same.
        public List<Profile_Mini> SearchByAll(UserSearch search, User self) {
            DateTime mindate = DateTime.Now.AddYears(-search.MinAge);
            DateTime maxdate = DateTime.Now.AddYears(-search.MaxAge);
            // if all then returns all the entries belonging to the category
            var list = from useri in dBEntityContext.Users_Info
                       join user in dBEntityContext.Users
                       on useri.UserId equals user.UserId
                       join usera in dBEntityContext.Users_Address_Info
                       on user.UserId equals usera.UserId
                       where (useri.DateOfBirth.CompareTo(mindate) + useri.DateOfBirth.CompareTo(maxdate) == 0)  &&
                             (useri.Gender.Equals(search.Gender)) &&
                             (useri.Education.Equals(search.Education)) &&
                             (usera.District.Equals(search.City))
                       select new Profile_Mini {UserId = user.UserId,
                                                UserName = user.UserName,
                                                Age = FindAgeFromDateTime(useri.DateOfBirth),
                                                ImageUrl = user.ImageUrl,
                                                Job = useri.Job
                                                };
            
            return list.ToList();
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

        
    }

    
}

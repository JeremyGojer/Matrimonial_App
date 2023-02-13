using Happy_Marriage.Models;
using Happy_Marriage.Utilities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Data.Odbc;

namespace Happy_Marriage.Utilities
{
    public class MyUtiltities:IUtilities
    {


        public int FindAgeFromDateTime(DateTime dob) {
            DateTime today = DateTime.Now;
            int age = 0;
            if (today.Month > dob.Month) {
                age = today.Year - dob.Year;
            }
            else if (today.Month == dob.Month && today.Day > dob.Day) {
                age = today.Year - dob.Year;
            }
            else { 
                age = today.Year - dob.Year - 1;
            }
            
            return age;
        }

    }
        
}

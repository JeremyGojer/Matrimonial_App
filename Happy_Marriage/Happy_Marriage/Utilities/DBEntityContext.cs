using Happy_Marriage.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Happy_Marriage.Utilities
{
    public class DBEntityContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<User_Info> Users_Info { get; set; }

        //public DbSet<User_Address_Info> Users_Address_Info { get; set; }
        //public DbSet<User_Other_Info> Users_Other_Info { get; set; }
        //public DbSet<User_Messages> Users_Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            string constring = null;
            if (constring == null){
                constring = @"server=127.0.0.1;uid=Jeremy;pwd=Jeremy;database=happy_marriage";
            }
            dbContextOptionsBuilder.UseMySQL(constring);
        } 
    }
}

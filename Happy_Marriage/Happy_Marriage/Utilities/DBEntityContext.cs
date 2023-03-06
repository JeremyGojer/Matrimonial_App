﻿using Happy_Marriage.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Happy_Marriage.Utilities
{
    public class DBEntityContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<User_Info> Users_Info { get; set; }
        public DbSet<User_Personal_Info> Users_Personal_Info { get; set; }
        public DbSet<User_Address_Info> Users_Address_Info { get; set; }
        
        //Storing message metadata and content
        public DbSet<User_Messages> Users_Messages { get; set; }

        //Deals with file local url and not the actual file
        public DbSet<User_Upload> Users_Uploads { get; set; }
        public DbSet<User_Request> Users_Requests { get; set; }
        public DbSet<User_Connections> Users_Friendships { get; set; }
        public DbSet<User_Metadata> Users_Metadata { get; set; }    
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        //to configure the database connection externally from program.cs and appsettings.json
        public DBEntityContext(DbContextOptions<DBEntityContext> options) : base(options) { 
        }

        //to configure the database connection from here
        /*protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            string constring = null;
            if (constring == null){
                constring = @"server=127.0.0.1;uid=Jeremy;pwd=Jeremy;database=happy_marriage";
            }
            dbContextOptionsBuilder.UseMySQL(constring);
        } */
    }
}

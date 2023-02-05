using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    public class User_Other_Info
    { 
        public int UserId { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
        
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{   
    public class User_Connections
    {
        [Key]
        public int Id { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

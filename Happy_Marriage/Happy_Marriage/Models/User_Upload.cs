using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    public class User_Upload
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ReceivedOn { get; set; }

    }
}

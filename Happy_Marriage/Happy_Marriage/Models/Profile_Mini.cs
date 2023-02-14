using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    //Fill the userid field when using this otherwise doesnt work as expected
    [Serializable]
    public class Profile_Mini
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int Age { get; set; }
        public string? ImageUrl { get; set; }
        public string? Job { get; set; }

    }
}

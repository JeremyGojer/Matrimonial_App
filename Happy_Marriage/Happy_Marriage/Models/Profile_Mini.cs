using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    //Frequently used for login purpose
    [Serializable]
    public class Profile_Mini
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Job { get; set; }

    }
}

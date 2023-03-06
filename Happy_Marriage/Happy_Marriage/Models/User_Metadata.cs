using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    //Frequently used for login purpose
    [Serializable]
    public class User_Metadata
    {
        [Key]
        public int UserId { get; set; }
        public string? CoverPicture { get; set; }
        public bool IsOnline { get; set; }

    }
}

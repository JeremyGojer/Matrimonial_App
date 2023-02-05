﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    [Serializable]
    public class User
    {
        public int UserId { get; set; }

        
        public string UserName { get; set; }

        
        public string Email { get; set; }

        
        public string Password { get; set; }

        
        public string ContactNumber { get; set; }
        
        public string Role { get; set; }

        public DateTime JoinedOn { get; set; }

    }
}

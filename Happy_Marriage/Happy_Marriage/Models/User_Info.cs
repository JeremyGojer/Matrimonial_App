﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    public class User_Info
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Religion { get; set; }

    }
}

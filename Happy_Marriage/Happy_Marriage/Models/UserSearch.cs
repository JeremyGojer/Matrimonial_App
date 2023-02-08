using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    public class UserSearch
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string? Gender { get; set; }
        public string? Education { get; set; }
        public string? City { get; set; }
    }
}

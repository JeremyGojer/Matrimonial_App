using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    
    public class ReportView
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int ReportCount { get; set; }
        

    }
}

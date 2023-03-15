using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    public class User_Report
    {
        [Key]
        public int Id { get; set; }
        public int ReportedOn { get; set; }
        public int ReportedBy { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    public class User_Personal_Info
    {
        [Key]
        public int UserId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string? FoodType { get; set; }
        public string? Smoking { get; set; }
        public string? Alcohol { get; set; }
        public string? BloodGroup { get; set; }
        public string? MartialStatus { get; set; }
        [DataType(DataType.Currency)]
        public double AnnualIncome { get; set; }


    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    //Taken from and for countries.csv
    public class State
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Country_Id { get; set; }
        public string? Country_Code { get; set; }
        public string? Fips_Code { get; set; }
        public string? Iso2 { get; set; }
        public double Latitude { get; set; }
        public double Longidute { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get;set; }
        public int Flag { get; set; }
        public string? WikiDataId { get; set; }

    }
}

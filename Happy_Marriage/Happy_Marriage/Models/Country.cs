using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    //Taken from and for countries.csv
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Iso3 { get; set; }
        public string? Iso2 { get; set; }
        public string? Phone_Code { get; set; }
        public string? Capital { get; set; }
        public string? Currency { get; set; }
        public string? Currency_Symbol { get; set; }
        public string? TLD { get; set; }
        public string? Native { get; set; }
        public string? Region { get; set; }
        public string? SubRegion { get; set; }
        public string? TimeZones { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Emoji { get; set; }
        public string? EmojiU { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Flag { get; set; }
        public string? WikiDataId { get; set; }

    }
}

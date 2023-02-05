using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{

    public class User_Address_Info
    {
        public int UserId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine1 { get; set;}

    }
}


using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    //For smtp server data retrival from appsettings.json and configuration
    public class EmailSettings
    {
        public string? EmailId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
    }
}

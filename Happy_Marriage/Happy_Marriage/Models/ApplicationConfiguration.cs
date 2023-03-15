using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    // This is model using by AppSettings.json for the configuration
    public class ApplicationConfiguration
    {
        public string? Directory { get; set; }
        

    }
}

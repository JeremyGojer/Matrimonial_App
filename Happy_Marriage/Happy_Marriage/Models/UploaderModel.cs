using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    
    public class UploaderModel
    {
        // asp.net default label 
        [Display(Name = "Select your file from the menu")]
        public IFormFile? File { get; set; }

    }
}

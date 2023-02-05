using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    public class User_Messages
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public DateTime ReceivedOn { get; set; }
        public string content { get; set; }
        public string status { get; set; }
    }
}

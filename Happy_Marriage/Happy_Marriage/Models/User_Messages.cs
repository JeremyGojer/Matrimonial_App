using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    public class User_Messages:IComparable<User_Messages>
    {
        [Key]
        public int MessageId { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public DateTime ReceivedOn { get; set; }
        public string? Content { get; set; }
        public string? Status { get; set; }
        public int CompareTo(User_Messages other)
        {
            return this.ReceivedOn.CompareTo(other.ReceivedOn);
        }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Happy_Marriage.Models
{
    
    public class SortChatByDate:IComparer<User_Messages>
    {
        public int Compare(User_Messages x, User_Messages y)
        {
            return x.ReceivedOn.CompareTo(y.ReceivedOn);
        }

    }
}

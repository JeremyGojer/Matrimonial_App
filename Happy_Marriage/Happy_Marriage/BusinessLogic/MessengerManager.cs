using Google.Protobuf.WellKnownTypes;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Utilities;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Security;

namespace Happy_Marriage.BusinessLogic
{
    public class MessengerManager:IMessengerManager
    {
        private readonly DBEntityContext dBEntityContext;
        public MessengerManager(DBEntityContext dBEntityContext) {
            this.dBEntityContext = dBEntityContext;
        }
        
        public List<User_Messages> ShowUserSentMessagesForChat(int senderId, int receiverId)
        {
            var msgs = from msg in dBEntityContext.Users_Messages where (msg.UserId1 == senderId && msg.UserId2 == receiverId) select msg;
            return msgs.ToList();
        }
        public List<User_Messages> ShowUserReceivedMessagesForChat(int senderId, int receiverId)
        {
            var msgs = from msg in dBEntityContext.Users_Messages where (msg.UserId1 == receiverId && msg.UserId2 == senderId) select msg;
            return msgs.ToList();
        }
        public List<User_Messages> ShowUserMessagesForChat(int senderId, int receiverId)
        {
            List<User_Messages> sent = ShowUserSentMessagesForChat(senderId, receiverId);
            List<User_Messages> rec = ShowUserReceivedMessagesForChat(senderId, receiverId);
            List<User_Messages> lst = sent.Concat(rec).ToList();
            //IComparer<User_Messages> sortChat = new SortChatByDate();
            lst.Sort();
            return lst;
        }
        public bool AddAMessage(User_Messages msg)
        {
            bool status = false;

            dBEntityContext.Users_Messages.Add(msg);
            dBEntityContext.SaveChanges();

            status = true;
            return status;
        }

    }

    
}

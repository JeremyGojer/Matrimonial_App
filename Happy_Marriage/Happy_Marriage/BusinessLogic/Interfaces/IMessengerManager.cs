using Happy_Marriage.Models;

namespace Happy_Marriage.BusinessLogic.Interfaces
{
    public interface IMessengerManager
    {
        public List<User_Messages> ShowUserSentMessagesForChat(int senderId, int receiverId);
        public List<User_Messages> ShowUserReceivedMessagesForChat(int senderId, int receiverId);
        public List<User_Messages> ShowUserMessagesForChat(int senderId, int receiverId);
        public bool AddAMessage(User_Messages msg);
    }
}

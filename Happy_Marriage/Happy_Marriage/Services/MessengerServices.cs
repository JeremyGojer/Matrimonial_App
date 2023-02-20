using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;

namespace Happy_Marriage.Services
{
    public class MessengerServices:IMessengerServices
    {
        private readonly IMessengerManager _messengerManager;
        //The Reference for Constructor Dependency Injection should be Interface Type
        public MessengerServices(IMessengerManager messengerManager) {
            _messengerManager = messengerManager;
        }

        public List<User_Messages> ShowUserSentMessagesForChat(int senderId, int receiverId) => _messengerManager.ShowUserSentMessagesForChat(senderId,receiverId);
        public List<User_Messages> ShowUserReceivedMessagesForChat(int senderId, int receiverId) => _messengerManager.ShowUserSentMessagesForChat(senderId, receiverId);
        public List<User_Messages> ShowUserMessagesForChat(int senderId, int receiverId) => _messengerManager.ShowUserMessagesForChat(senderId,receiverId);
        public bool AddAMessage(User_Messages msg) => _messengerManager.AddAMessage(msg);
    }
}

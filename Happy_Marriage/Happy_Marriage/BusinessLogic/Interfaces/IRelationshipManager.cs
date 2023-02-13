using Happy_Marriage.Models;

namespace Happy_Marriage.BusinessLogic.Interfaces
{
    public interface IRelationshipManager
    {
        public bool SendRequest(int userid1, int userid2);
        public bool AcceptRequest(int userid1, int userid2);
        public bool RejectRequest(int userid1, int userid2);
        public bool CancelRequest(int userid1, int userid2);
        public List<Profile_Mini> AllReceivedRequests(User user);
        public List<Profile_Mini> AllSentRequests(User user);
        public bool IfRequestSent(int userid1, int userid2);
        public bool IfRequestReceived(int userid1, int userid2);
    }
}

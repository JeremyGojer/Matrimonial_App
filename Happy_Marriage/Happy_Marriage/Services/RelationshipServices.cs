using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;

namespace Happy_Marriage.Services
{
    public class RelationshipServices: IRelationshipServices
    {
        private readonly IRelationshipManager _relationshipManager;
        //The Reference for Constructor Dependency Injection should be Interface Type
        public RelationshipServices(IRelationshipManager relationshipManager) {
            _relationshipManager = relationshipManager;
        }

        public bool SendRequest(int userid1, int userid2) => _relationshipManager.SendRequest(userid1,userid2);
        public bool AcceptRequest(int userid1, int userid2) => _relationshipManager.AcceptRequest(userid1,userid2);
        public bool RejectRequest(int userid1, int userid2) => _relationshipManager.RejectRequest(userid1,userid2);
        public bool CancelRequest(int userid1, int userid2) => _relationshipManager.CancelRequest(userid1, userid2);
        public List<Profile_Mini> AllReceivedRequests(User user) => _relationshipManager.AllReceivedRequests(user);
        public List<Profile_Mini> AllSentRequests(User user) => _relationshipManager.AllSentRequests(user);
        public bool IfRequestSent(int userid1, int userid2) => _relationshipManager.IfRequestSent(userid1,userid2);
        public bool IfRequestReceived(int userid1, int userid2) => _relationshipManager.IfRequestReceived(userid1,userid2);
    }
}

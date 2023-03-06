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
    
    public class AccountManager:IAccountManager
    {
        private readonly DBEntityContext dBEntityContext;
        public AccountManager(DBEntityContext dBEntityContext) {
            this.dBEntityContext = dBEntityContext;
        }

        public User AcceptAccount(User user) {
            user.ApprovalStatus = "Accepted";
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();
            return user;
        }

        public User RejectAccount(User user)
        {
            user.ApprovalStatus = "Rejected";
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();
            return user;
        }

        public User BanAccount(User user)
        {
            user.ApprovalStatus = "Banned";
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();
            return user;
        }

    }

    
}

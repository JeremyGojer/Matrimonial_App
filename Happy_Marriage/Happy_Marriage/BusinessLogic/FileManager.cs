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
    // Manages both User and User_Info TABLES
    public class FileManager:IFileManager
    {
        private readonly DBEntityContext dBEntityContext;
        public FileManager(DBEntityContext dBEntityContext) {
            this.dBEntityContext = dBEntityContext;
        }

        public bool Upload(User_Upload file) {
            bool status = false;

            dBEntityContext.Users_Uploads.Add(file);
            dBEntityContext.SaveChanges();
            status = true;

            return status;
        }

        public List<User_Upload> AllUserImagesUrl(User user) {
            var list = from userimgs in dBEntityContext.Users_Uploads where (userimgs.UserId == user.UserId) select userimgs;
            

            return list.ToList();
        }

    
    }

    
}

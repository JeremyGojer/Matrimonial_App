using Google.Protobuf.WellKnownTypes;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Utilities;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Microsoft.EntityFrameworkCore;
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

        public bool SetAsProfilePicture(string url, User user) {

            bool status = false;
            Console.WriteLine(user.ImageUrl);
            Console.WriteLine(url);
            user.ImageUrl= url;
            //Update in database
            dBEntityContext.Users.Update(user);
            dBEntityContext.SaveChanges();

            status = true;
            return status;

        }

        public bool SetAsCoverPicture(string url, User user)
        {
            bool status = false;
            user.ImageUrl = url;
            User_Metadata metadata = new User_Metadata();
            metadata.UserId = user.UserId;
            metadata.CoverPicture = url;
            dBEntityContext.Users_Metadata.Update(metadata);
            dBEntityContext.SaveChanges();

            status = true;
            return status;
        }
        public User_Upload GetFileDataFromUrl(string url) {
            var datalist = from d in dBEntityContext.Users_Uploads where (url == d.ImageUrl) select d;
            var data = datalist.FirstOrDefault(d => url == d.ImageUrl);
            return data;
        }
        public User_Metadata GetUserMetadata(User user)
        {
            var data = from d in dBEntityContext.Users_Metadata where d.UserId == user.UserId select d;
            var da = data.FirstOrDefault();
            return da;
        }

        public bool DeletePicture(string url, User user) {
            bool status = false;
            if(File.Exists("wwwroot"+url)) {
                File.Delete("wwwroot"+url);
                User_Upload filedata = GetFileDataFromUrl(url);
                dBEntityContext.Users_Uploads.Remove(filedata);
                
                if (url == user.ImageUrl) {
                    user.ImageUrl = "/images/Default_Profile_Pic.jpg";
                    dBEntityContext.Users.Update(user);
                }
                User_Metadata metaData = GetUserMetadata(user);
                if (url == metaData.CoverPicture) {
                    metaData.CoverPicture = null;
                    dBEntityContext.Users_Metadata.Update(metaData);
                }
                dBEntityContext.SaveChanges();
                status = true;
            }    

            return status;
        }

        
    
    }

    
}

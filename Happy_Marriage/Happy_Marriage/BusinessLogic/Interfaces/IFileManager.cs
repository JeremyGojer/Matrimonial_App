using Happy_Marriage.Models;

namespace Happy_Marriage.BusinessLogic.Interfaces
{
    public interface IFileManager
    {
        public bool Upload(User_Upload file);

        public List<User_Upload> AllUserImagesUrl(User user);

        public bool SetAsProfilePicture(string url, User user);
        public bool SetAsCoverPicture(string url, User user);
        public bool DeletePicture(string url, User user);
    }
}

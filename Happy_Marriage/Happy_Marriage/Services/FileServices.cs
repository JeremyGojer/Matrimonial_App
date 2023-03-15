using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;

namespace Happy_Marriage.Services
{
    public class FileServices:IFileServices
    {
        private readonly IFileManager _fileManager;
        //The Reference for Constructor Dependency Injection should be Interface Type
        public FileServices(IFileManager fileManager) { 
             _fileManager = fileManager;
        }

        public bool Upload(User_Upload file) => _fileManager.Upload(file);
        public List<User_Upload> AllUserImagesUrl(User user) => _fileManager.AllUserImagesUrl(user);
        public bool SetAsProfilePicture(string url, User user) => _fileManager.SetAsProfilePicture(url, user);

        public bool SetAsCoverPicture(string url, User user) => _fileManager.SetAsCoverPicture(url, user);
        public bool DeletePicture(string url, User user) => _fileManager.DeletePicture(url, user);


    }
}

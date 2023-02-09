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




    }
}

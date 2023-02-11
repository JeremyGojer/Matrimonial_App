﻿using Happy_Marriage.Models;

namespace Happy_Marriage.Services.Interfaces
{
    public interface IFileServices
    {
        public bool Upload(User_Upload file);
        public List<User_Upload> AllUserImagesUrl(User user);
    }
}
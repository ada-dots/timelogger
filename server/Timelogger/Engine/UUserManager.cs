using System;
using Timelogger.Entities;
using Timelogger.Entities.DTO;

namespace Timelogger.Engine
{
    public class UUserManager:BaseManager
    {
        public UUserManager(ApiContext context) : base(context)
        {

        }

        public UserDTO GetUser(int userId)
        {
           User item = _repository.GetAllUsers().Find(x => x.UserId == userId);
           return item.AsDTO();
        }

        public bool ExistUser(int userId)
        {
            var currentUser = GetUser(userId); 
            return currentUser != null;
        }
    }
}
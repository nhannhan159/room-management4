using RoomM.Model.RepositoryFramework;
using RoomM.Models.Users;
using RoomM.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Business.Rooms
{
    public class UserService
    {
        private static IUserRepository userRepo;

        static UserService()
        {
            userRepo = RepositoryFactory.GetRepository<IUserRepository, User>();
        }

        public static User GetByID(int id)
        {
            return userRepo.GetSingle(id);
        }

        public static Boolean CheckPassword(User u, string password)
        {
            return userRepo.CheckPassword(u, password);
        }

        public static Boolean CheckUserExists(string username)
        {
            return userRepo.CheckUserExists(username);
        }


    }
}

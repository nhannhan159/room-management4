using RoomM.Model;
using RoomM.Model.RepositoryFramework;
using RoomM.Models.Users;
using RoomM.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Users
{
    public class UserRepository : RepositoryBase<EFDataContext, User>, IUserRepository
    {
        public UserRepository()
        {

        }

        public User GetSingle(int userId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == userId);
            return query;
        }


        public bool CheckPassword(User user, string password)
        {
            return user.Password.Equals(password);
        }

        public bool CheckUserExists(string username)
        {
            return (from p in GetAllWithQuery()
                    where p.UserName.Equals(username)
                    select p).ToList().Count != 0;
        }
    }
}

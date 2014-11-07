using RoomM.Model.RepositoryFramework;
using RoomM.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetSingle(int userId);
        Boolean CheckPassword(User user, string password);
        Boolean CheckUserExists(string username);
    }
}

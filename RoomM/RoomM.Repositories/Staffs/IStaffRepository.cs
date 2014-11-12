using RoomM.Model.RepositoryFramework;
using RoomM.Models.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Staffs
{
    public interface IStaffRepository : IRepository<Staff>
    {
        Staff GetSingle(int staffId);
        Boolean CheckPassword(Staff staff, string password);
        Boolean CheckUserExists(string username);
    }
}

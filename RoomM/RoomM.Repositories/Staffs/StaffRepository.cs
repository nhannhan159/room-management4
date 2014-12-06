using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Staffs
{
    public class StaffRepository : RepositoryBase<EFDataContext, Staff>, IStaffRepository
    {
        public StaffRepository()
        {

        }

        public Staff GetSingle(int staffId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == staffId);
            return query;
        }


        public bool CheckPassword(Staff staff, string password)
        {
            return staff.Password.Equals(password);
        }

        public bool CheckUserExists(string username)
        {
            return (from p in GetAllWithQuery()
                    where p.UserName.Equals(username)
                    select p).ToList().Count != 0;
        }


        public IList<Staff> GetStaffLimitByRegister(int limit)
        {
            return (from p in GetAllWithQuery()
                    orderby p.RoomCalendars.Count descending
                    select p).Take(limit).ToList();
        }
    }
}

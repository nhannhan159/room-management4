﻿using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RoomM.Repositories.Staffs
{
    public interface IStaffRepository : IRepository<Staff>
    {
        Staff GetSingle(int staffId);
        Boolean CheckPassword(Staff staff, string password);
        Boolean CheckUserExists(string username);
        IList<Staff> GetStaffLimitByRegister(int limit);
        List<DictionaryEntry> GetStaffLimitByRegister(int limit, DateTime from, DateTime to);
        bool IsExists(string username);
        int GetUserId(string username);

       bool UserNameIsWorking(string username);
    }
}

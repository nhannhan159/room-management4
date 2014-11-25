﻿using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public interface IRoomCalendarRepository : IRepository<RoomCalendar>
    {
        RoomCalendar GetSingle(int roomCalId);
        IList<RoomCalendar> GetByRoomId(int roomId);
        IList<RoomCalendar> GetByStaffId(int staffId);
        IList<RoomCalendar> GetByDate(DateTime date);
        IList<RoomCalendar> GetByDateAndRoomId(DateTime date, long roomId);
        IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, long roomId);

    }
}

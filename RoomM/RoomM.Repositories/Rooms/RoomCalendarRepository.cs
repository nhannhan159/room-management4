using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public class RoomCalendarRepository : RepositoryBase<EFDataContext, RoomCalendar>, IRoomCalendarRepository
    {
        public RoomCalendarRepository()
        { 
        }

        public RoomCalendar GetSingle(int roomCalId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomCalId);
            return query;
        }

        public IList<RoomCalendar> GetByRoomId(int roomId)
        {
            return (from p in GetAllWithQuery()
                    where p.Room.ID == roomId
                    select p).ToList();
        }
    }
}

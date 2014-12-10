using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomM.Models.Rooms;
using RoomM.Model;

namespace RoomM.Repositories.Rooms
{
    public class RoomRepository : RepositoryBase<EFDataContext, Room>, IRoomRepository
    {
        public RoomRepository()
        { 
        }

        public Room GetSingle(Int64 roomId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomId);
            return query;
        }

        public IList<Room> GetByRoomTypeId(long roomTypeId)
        {
            return (from p in GetAllWithQuery()
                    where p.RoomType.ID == roomTypeId
                    select p).ToList();
        }

        public IList<Room> GetRoomListLimitByRegister(int limit)
        {
            return (from p in GetAllWithQuery()
                    orderby p.RoomCalendars.Count descending
                    select p).Take(limit).ToList();
        }
    }
}

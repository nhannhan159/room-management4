using RoomM.Model;
using RoomM.Model.RepositoryFramework;
using RoomM.Model.Rooms;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public class RoomDeviceRepository : RepositoryBase<EFDataContext, RoomDevice>, IRoomDeviceRepository
    {
        public RoomDeviceRepository()
        { 

        }

        public RoomDevice GetSingle(int roomDeviceId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomDeviceId);
            return query;
        }


        public IList<RoomDevice> GetByRoomId(int id)
        {
            return (from p in GetAllWithQuery()
                    where p.Room.ID == id
                    select p).ToList();
        }
    }
}

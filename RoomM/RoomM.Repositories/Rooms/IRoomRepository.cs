using RoomM.Models.Rooms;
using RoomM.Repositories.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room GetSingle(Int64 roomId);
        IList<Room> GetByRoomTypeId(Int64 roomTypeId);
        IList<Room> GetRoomListLimitByRegister(int limit);
    }
}

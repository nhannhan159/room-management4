using RoomM.Model.RepositoryFramework;
using RoomM.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public interface IRoomDeviceRepository : IRepository<RoomDevice>
    {
        RoomDevice GetSingle(int roomDeviceId);
        IList<RoomDevice> GetByRoomId(int id);
    }
}

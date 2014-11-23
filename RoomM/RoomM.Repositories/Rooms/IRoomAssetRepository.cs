using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public interface IRoomAssetRepository : IRepository<RoomAsset>
    {
        RoomAsset GetSingle(int roomDeviceId);
        IList<RoomAsset> GetByRoomId(int id);
    }
}

using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public class RoomAssetRepository : RepositoryBase<EFDataContext, RoomAsset>, IRoomAssetRepository
    {
        public RoomAssetRepository()
        { 

        }

        public RoomAsset GetSingle(int roomDeviceId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomDeviceId);
            return query;
        }


        public IList<RoomAsset> GetByRoomId(int id)
        {
            return (from p in GetAllWithQuery()
                    where p.Room.ID == id
                    select p).ToList();
        }
    }
}

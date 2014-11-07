using RoomM.Model;
using RoomM.Model.RepositoryFramework;
using RoomM.Model.Rooms;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    // public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    public class RoomTypeRepository : RepositoryBase<EFDataContext, RoomType>, IRoomTypeRepository
    {

        public RoomTypeRepository()
        { 
        
        }

        public RoomType GetSingle(int roomTypeId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomTypeId);
            return query;
        }
    }
}

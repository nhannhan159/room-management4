using RoomM.Models;
using RoomM.Model.RepositoryFramework;
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

        public Room GetSingle(int roomId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomId);
            return query;
        }
    }
}

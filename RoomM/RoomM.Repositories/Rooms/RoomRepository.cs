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
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(EFDataContext context)
            : base(context)
        {
            // add -CRUD here 
        }
    }
}

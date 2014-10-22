using RoomM.Models.Entities;
using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

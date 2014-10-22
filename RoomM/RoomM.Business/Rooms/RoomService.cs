using RoomM.Models;
using RoomM.Models.Devices;
using RoomM.Repositories.Rooms;
using RoomM.Repositories.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomM.Models.Rooms;

namespace RoomM.Business.Rooms
{
    public partial class RoomService
    {
        public static IRoomRepository repository;
        
        static RoomService()
        {
            repository = RepositoryFactory.GetRepository<IRoomRepository, Room>();
        }

        public static IList<Room> GetAll()
        {
            return RoomService.repository.GetAll();
        }

        public static Room GetByID(int id)
        {
            return RoomService.repository.GetByID(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.WebApp.Models.Room
{
    public class GetAllRoomModel
    {
        public IEnumerable<RoomCommon> RoomCommons { get; set; }
    }

    public class RoomCommon {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
    }

}

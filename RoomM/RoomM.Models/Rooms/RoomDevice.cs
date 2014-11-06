using RoomM.Models;
using RoomM.Models.Devices;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Model.Rooms
{
    public class RoomDevice : EntityBase
    {
        public Int64 RoomId { get; set; }
        public virtual Room Room { get; set; }

        public Int64 DeviceId { get; set; }
        public virtual Device Device { get; set; }

        public int Amount { get; set; }

    }
}

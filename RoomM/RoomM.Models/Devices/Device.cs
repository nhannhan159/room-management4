using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Devices
{
    public class Device : EntityBase
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public Int64 DeviceTypeId { get; set; }
        public Int64 RoomId { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        public virtual Room Room { get; set; }
    }
}

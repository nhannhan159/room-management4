using RoomM.Models.Devices;
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
        public int DeviceTypeId { get; set; }
        public int RoomId { get; set; }
        public virtual DeviceType DeviceType { get; set; }
    }
}

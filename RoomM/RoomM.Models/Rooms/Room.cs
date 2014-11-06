using RoomM.Models.Devices;
using RoomM.Model.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Rooms
{
    public class Room : EntityBase
    {
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public Int64 RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }

        // public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<RoomDevice> RoomDevices { get; set; }
        public virtual ICollection<DeviceHistory> DeviceHistorys { get; set; }
        public virtual ICollection<RoomCalendar> RoomCalendars { get; set; }
    }
}

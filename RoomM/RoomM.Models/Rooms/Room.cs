using RoomM.Models.Devices;
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
        public virtual ICollection<Device> Devices { get; set; }
    }
}

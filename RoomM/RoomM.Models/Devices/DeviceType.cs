using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Devices
{
    public class DeviceType : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}

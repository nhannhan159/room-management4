using RoomM.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Entities
{
    [Table("Devices")]
    public class Device : EntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Amount { get; set; }

        [ForeignKey("DeviceType")]
        public int DeviceTypeId { get; set; }

        public int RoomId { get; set; }

        public virtual DeviceType DeviceType { get; set; }
    }
}

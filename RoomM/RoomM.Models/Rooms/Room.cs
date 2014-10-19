using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Rooms
{
    [Table("Rooms")]
    public class Room : EntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime DateCreate { get; set; }

        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}

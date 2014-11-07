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
        [Required]
        [Display(Name = "Ten phong")]
        [StringLength(120)]
        public string Name { get; set; }

        [Display(Name = "Ngay tao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Loai phong")]
        public Int64 RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }

        public Boolean IsUsing { get; set; }

        public virtual ICollection<RoomDevice> RoomDevices { get; set; }
        public virtual ICollection<DeviceHistory> DeviceHistorys { get; set; }
        public virtual ICollection<RoomCalendar> RoomCalendars { get; set; }


        public override string ToString()
        {
            return ID + "#" + Name + "#RoomType:" + RoomTypeId + "#Status: " + IsUsing;
        }

    }
}

using RoomM.Models.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Rooms
{
    public class RoomCalendar : EntityBase
    {
        public DateTime Date { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }

        public Int64 RoomId { get; set; }
        public virtual Room Room { get; set; }

        public Int64 StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public Int64 RoomCalendarStatusId { get; set; }
        public virtual RoomCalendarStatus RoomCalendarStatus { get; set; }

        public bool IsWatched { get; set; }

        public override string ToString()
        {
            return ID + " #room " + RoomId + " #user " + StaffId + " #start " + Start + " #len " + Length + " #cal " + RoomCalendarStatus.Name;
        }
    }
}

using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Assets
{
    public class RoomAssetHistory : EntityBase
    {
        public Int64 AssetHistoryTypeId { get; set; }
        public virtual HistoryType HistoryType { get; set; }
        
        public DateTime Date { get; set; }

        public Int64 AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public Int64 RoomId { get; set; }
        public virtual Room Room { get; set; }


        public override string ToString()
        {
            return ID + " # " + " #type:" + AssetHistoryTypeId + " #roomID: " + RoomId;
        }

    }
}

﻿using RoomM.Models;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RoomM.Models.Assets;

namespace RoomM.Model.Rooms
{
    public class RoomAsset : EntityBase
    {
        public Int64 RoomId { get; set; }
        public virtual Room Room { get; set; }

        public Int64 AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public int Amount { get; set; }


        public override string ToString()
        {
            return ID + " #RoomId: " + RoomId + " #DeviceId: " + AssetId + " #amount: " + Amount;
        }

    }
}

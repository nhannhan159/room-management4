using RoomM.Models.Rooms;
using RoomM.Model.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Assets
{
    public class Asset : EntityBase
    {
        public string Name { get; set; }
        public Boolean IsUsing { get; set; }

        public virtual ICollection<RoomAsset> RoomAssets { get; set; }
        public virtual ICollection<RoomAssetHistory> AssetHistories { get; set; }

        public override string ToString()
        {
            return ID + " # " + Name;
        }

    }
}

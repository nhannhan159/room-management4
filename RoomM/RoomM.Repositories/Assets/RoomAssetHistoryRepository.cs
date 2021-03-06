﻿using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Assets;
using RoomM.Repositories.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomM.Models.Rooms;

namespace RoomM.Repositories.Assets
{
    public class RoomAssetHistoryRepository : RepositoryBase<EFDataContext, RoomAssetHistory>, IRoomAssetHistoryRepository
    {
        public RoomAssetHistoryRepository()
        { 
        
        }

        public RoomAssetHistory GetSingle(int assetId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == assetId);
            return query;
        }

        public IList<RoomAssetHistory> GetByRoomId(Int64 id)
        {
            return (from p in GetAllWithQuery()
                    where p.Room.ID == id
                    select p).ToList();
        }

        public IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return (from p in GetAllWithQuery()
                    where (p.Room2.Equals(room.Name) || p.Room.ID == room.ID)
                    orderby p.Date
                    select p).ToList();
        }
    }
}

﻿using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomM.Models.Rooms;

namespace RoomM.Repositories.Assets
{
    public interface IRoomAssetHistoryRepository : IRepository<RoomAssetHistory>
    {
        RoomAssetHistory GetSingle(int id);
        IList<RoomAssetHistory> GetByRoomId(Int64 id);
        // List<RoomAssetHistory> GetHistoriesByToRoomId(Int64 roomId);
        IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace);
    }
}

using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Assets;
using RoomM.Repositories.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}

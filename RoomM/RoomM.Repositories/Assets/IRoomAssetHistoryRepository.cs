using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Assets
{
    public interface IRoomAssetHistoryRepository : IRepository<RoomAssetHistory>
    {
        RoomAssetHistory GetSingle(int id);
        
        
    }
}

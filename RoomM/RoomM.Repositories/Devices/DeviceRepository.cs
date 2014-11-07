using RoomM.Model;
using RoomM.Model.RepositoryFramework;
using RoomM.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Devices
{
    public class DeviceRepository : RepositoryBase<EFDataContext, Device>, IDeviceRepository
    {
        public DeviceRepository()
        { 
        
        }

        public Device GetSingle(int deviceId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == deviceId);
            return query;
        }


        public IList<string> GetNameList()
        {
            return (from p in GetAllWithQuery()
                    select p.Name).ToList();
        }
    }
}

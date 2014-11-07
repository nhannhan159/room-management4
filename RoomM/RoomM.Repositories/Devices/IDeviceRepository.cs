using RoomM.Model.RepositoryFramework;
using RoomM.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Devices
{
    public interface IDeviceRepository : IRepository<Device>
    {
        Device GetSingle(int deviceId);
        IList<String> GetNameList();
        
    }
}

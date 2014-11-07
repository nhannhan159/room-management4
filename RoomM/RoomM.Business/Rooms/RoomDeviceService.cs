using RoomM.Model.RepositoryFramework;
using RoomM.Model.Rooms;
using RoomM.Models.Devices;
using RoomM.Models.Rooms;
using RoomM.Repositories.Devices;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Business.Rooms
{
    public class RoomDeviceService
    {
        public static IRoomDeviceRepository roomDeviceRepo;
        public static IDeviceRepository deviceRepo;

        static RoomDeviceService()
        {
            roomDeviceRepo = RepositoryFactory.GetRepository<IRoomDeviceRepository, RoomDevice>();
            deviceRepo = RepositoryFactory.GetRepository<IDeviceRepository, Device>();
        }

        // get all room device list
        public static IList<RoomDevice> GetAll() 
        {
            return roomDeviceRepo.GetAll();
        }

        public static RoomDevice GetByID(int id)
        {
            return roomDeviceRepo.GetSingle(id);
        }

        // get all room device with room id
        public static IList<RoomDevice> GetByRoomId(int id)
        {
            return roomDeviceRepo.GetByRoomId(id);
        }


        // get all device exist in store
        public static IList<Device> GetAllDevice()
        {
            return deviceRepo.GetAll();
        }

        // get all device label
        public static IList<String> GetAllDeviceName()
        {
            return deviceRepo.GetNameList();
        }

        public static void Add(RoomDevice roomDevice)
        {
            roomDeviceRepo.Add(roomDevice);
        }

        public static void Edit(RoomDevice roomDevice)
        {
            roomDeviceRepo.Edit(roomDevice);
        }

        public static void Delete(RoomDevice roomDevice)
        {
            roomDeviceRepo.Delete(roomDevice);
        }

        // commit changes
        public static void Save()
        {
            roomDeviceRepo.Save();
        }

    }
}

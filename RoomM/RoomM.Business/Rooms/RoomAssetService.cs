﻿using RoomM.Model.RepositoryFramework;
using RoomM.Model.Rooms;
using RoomM.Models.Assets;
using RoomM.Models.Rooms;
using RoomM.Repositories.Assets;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Business.Rooms
{
    public class RoomAssetService
    {
        public static IRoomAssetRepository roomDeviceRepo;
        public static IAssetRepository deviceRepo;

        static RoomAssetService()
        {
            roomDeviceRepo = RepositoryFactory.GetRepository<IRoomAssetRepository, RoomAsset>();
            deviceRepo = RepositoryFactory.GetRepository<IAssetRepository, Asset>();
        }

        // get all room device list
        public static IList<RoomAsset> GetAll() 
        {
            return roomDeviceRepo.GetAll();
        }

        public static RoomAsset GetByID(int id)
        {
            return roomDeviceRepo.GetSingle(id);
        }

        // get all room device with room id
        public static IList<RoomAsset> GetByRoomId(int id)
        {
            return roomDeviceRepo.GetByRoomId(id);
        }


        // get all device exist in store
        public static IList<Asset> GetAllAsset()
        {
            return deviceRepo.GetAll();
        }

        // get all device label
        public static IList<String> GetAllDeviceName()
        {
            return deviceRepo.GetNameList();
        }

        public static void Add(RoomAsset roomDevice)
        {
            roomDeviceRepo.Add(roomDevice);
        }

        public static void Edit(RoomAsset roomDevice)
        {
            roomDeviceRepo.Edit(roomDevice);
        }

        public static void Delete(RoomAsset roomDevice)
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
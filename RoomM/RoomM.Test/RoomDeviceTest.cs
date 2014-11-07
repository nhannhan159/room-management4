using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RoomM.Model.Rooms;
using RoomM.Business.Rooms;
using RoomM.Models.Devices;

namespace RoomM.Test
{

    public class RoomDeviceTest
    {

        public void showRoomDeviceList()
        {
            IList<RoomDevice> lst = RoomDeviceService.GetAll();

            Console.WriteLine("Room device list:");
            foreach (RoomDevice rm in lst)
            {
                Console.WriteLine(rm.ToString());
            }
        
        }

      
        public void FindRoomDeviceTest()
        {
            showRoomDeviceList();

            // RoomDeviceService.Add


            RoomDevice dl = RoomDeviceService.GetByID(1);


            Console.WriteLine(dl.ToString());


            dl.Amount = 0;


            RoomDeviceService.Delete(dl);
            RoomDeviceService.Save();


            showRoomDeviceList();


        }

   
        public void AddRoomDeviceTest()
        { 
            RoomDevice rm = new RoomDevice
            {
                RoomId = 1,
                DeviceId = 1,
                Amount = 150,
            };


            RoomDeviceService.Add(rm);
            RoomDeviceService.Save();
            showRoomDeviceList();

        }

        [TestMethod]
        public void GetByRoomIdTest()
        {
            IList<RoomDevice> lst = RoomDeviceService.GetByRoomId(1);

            foreach (RoomDevice rm in lst)
                Console.WriteLine(rm.ToString());
        }


        [TestMethod]
        public void GetAllDeviceTest()
        {
            IList<Device> lst = RoomDeviceService.GetAllDevice();

            foreach (Device d in lst)
                Console.WriteLine(d.ToString());

        }
    }
}

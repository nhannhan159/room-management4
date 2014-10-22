using RoomM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories
{
    public class RoomMgrContextCustomInitializer : DropCreateDatabaseAlways<EFDataContext>
    {

        protected override void Seed(EFDataContext context)
        {

            var roomTH = new RoomType { Id = 1, Name = "Thuc hanh tin hoc" };
            var roomBi = new RoomType { Id = 2, Name = "Thuc hanh hoa" };
            var roomPy = new RoomType { Id = 3, Name = "Thuc hanh li" };
            var roomLi = new RoomType { Id = 4, Name = "Thuc hanh li thuyet" };

            var room1 = new Room
            {
                Id =1,
                Name = "A111",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };

            var room2 = new Room
            {
                Id = 2,
                Name = "B006",
                DateCreate = new DateTime(2011, 1, 2),
                RoomType = roomLi
            };

            var devicetype1 = new DeviceType { Id = 1, Name = "Thiet bi dien tu" };
            var devicetype2 = new DeviceType { Id = 2, Name = "Cong cu thi nghiem" };

            var device1 = new Device
            {
                Id = 1,
                Name = "DV001",
                DeviceType = devicetype1,
                Amount = 5
            };

            var device2 = new Device
            {
                Id = 2,
                Name = "DV002",
                DeviceType = devicetype1,
                Amount = 10
            };

            var device3 = new Device
            {
                Id = 3,
                Name = "DV003",
                DeviceType = devicetype2,
                Amount = 3
            };

            var device4 = new Device
            {
                Id = 4,
                Name = "DV004",
                DeviceType = devicetype2,
                Amount = 4
            };

            context.RoomTypes.Add(roomTH);
            context.RoomTypes.Add(roomBi);
            context.RoomTypes.Add(roomPy);
            context.RoomTypes.Add(roomLi);

            context.Rooms.Add(room1);
            context.Rooms.Add(room2);

            context.DeviceTypes.Add(devicetype1);
            context.DeviceTypes.Add(devicetype2);

            context.Devices.Add(device1);
            context.Devices.Add(device2);
            context.Devices.Add(device3);
            context.Devices.Add(device4);

            // context.Entry()
            
            int i = context.SaveChanges();
            Console.WriteLine("{0} records added...", i);
        }
       

        
    }
}

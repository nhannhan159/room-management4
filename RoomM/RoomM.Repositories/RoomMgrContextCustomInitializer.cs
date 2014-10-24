using RoomM.Models.Devices;
using RoomM.Models.Rooms;
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

            RoomType roomTH = new RoomType { Name = "Thuc hanh tin hoc" };
            RoomType roomBi = new RoomType { Name = "Thuc hanh hoa" };
            RoomType roomPy = new RoomType { Name = "Thuc hanh li" };
            RoomType roomLi = new RoomType { Name = "Thuc hanh li thuyet" };

            DeviceType devicetype1 = new DeviceType { Name = "Thiet bi dien tu" };
            DeviceType devicetype2 = new DeviceType { Name = "Cong cu thi nghiem" };

            Room room1 = new Room
            {
                Name = "A111",
                DateCreate = new DateTime(2011, 1, 1),
                RoomType = roomTH
            };
            Room room2 = new Room
            {
                Name = "B006",
                DateCreate = new DateTime(2011, 1, 2),
                RoomType = roomLi
            };

            Device device1 = new Device
            {
                Name = "DV001",
                DeviceType = devicetype1,
                Room = room2,
                Amount = 5
            };
            Device device2 = new Device
            {
                Name = "DV002",
                DeviceType = devicetype1,
                Room = room1,
                Amount = 10
            };
            Device device3 = new Device
            {
                Name = "DV003",
                DeviceType = devicetype2,
                Room = room2,
                Amount = 3
            };
            Device device4 = new Device
            {
                Name = "DV004",
                DeviceType = devicetype2,
                Room = room2,
                Amount = 4
            };

            context.Entry(roomTH).State = EntityState.Added;
            context.Entry(roomBi).State = EntityState.Added;
            context.Entry(roomPy).State = EntityState.Added;
            context.Entry(roomLi).State = EntityState.Added;

            context.Entry(devicetype1).State = EntityState.Added;
            context.Entry(devicetype2).State = EntityState.Added;

            context.Entry(room1).State = EntityState.Added;
            context.Entry(room2).State = EntityState.Added;

            context.Entry(device1).State = EntityState.Added;
            context.Entry(device2).State = EntityState.Added;
            context.Entry(device3).State = EntityState.Added;
            context.Entry(device4).State = EntityState.Added;

            context.SaveChanges();
        }
       

        
    }
}

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

            DeviceHistoryType devicehistorytype1 = new DeviceHistoryType { Name = "Device History Type 1" };
            DeviceHistoryType devicehistorytype2 = new DeviceHistoryType { Name = "Device History Type 2" };

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
            Room room3 = new Room
            {
                Name = "A112",
                DateCreate = new DateTime(2011, 1, 3),
                RoomType = roomTH
            };
            Room room4 = new Room
            {
                Name = "B005",
                DateCreate = new DateTime(2011, 1, 5),
                RoomType = roomPy
            };
            Room room5 = new Room
            {
                Name = "A142",
                DateCreate = new DateTime(2011, 1, 7),
                RoomType = roomBi
            };
            Room room6 = new Room
            {
                Name = "B008",
                DateCreate = new DateTime(2011, 1, 8),
                RoomType = roomLi
            };

            Device device1 = new Device
            {
                Name = "DV001",
                DeviceType = devicetype1,
                Amount = 5,
                Rooms = new List<Room> { room1, room3 }
            };
            Device device2 = new Device
            {
                Name = "DV002",
                DeviceType = devicetype1,
                Amount = 10,
                Rooms = new List<Room> { room1, room4, room6 }
            };
            Device device3 = new Device
            {
                Name = "DV003",
                DeviceType = devicetype2,
                Amount = 3,
                Rooms = new List<Room> { room2 }
            };
            Device device4 = new Device
            {
                Name = "DV004",
                DeviceType = devicetype2,
                Amount = 4,
                Rooms = new List<Room> { room2, room3 }
            };

            DeviceHistory devicehistory1 = new DeviceHistory
            {
                Date = new DateTime(2011, 1, 1),
                DeviceHistoryType = devicehistorytype1,
                Device = device3,
                Room = room6,
            };
            DeviceHistory devicehistory2 = new DeviceHistory
            {
                Date = new DateTime(2011, 1, 3),
                DeviceHistoryType = devicehistorytype1,
                Device = device1,
                Room = room1,
            };
            DeviceHistory devicehistory3 = new DeviceHistory
            {
                Date = new DateTime(2011, 1, 5),
                DeviceHistoryType = devicehistorytype2,
                Device = device2,
                Room = room2,
            };

            context.Entry(roomTH).State = EntityState.Added;
            context.Entry(roomBi).State = EntityState.Added;
            context.Entry(roomPy).State = EntityState.Added;
            context.Entry(roomLi).State = EntityState.Added;

            context.Entry(devicetype1).State = EntityState.Added;
            context.Entry(devicetype2).State = EntityState.Added;

            context.Entry(devicehistorytype1).State = EntityState.Added;
            context.Entry(devicehistorytype2).State = EntityState.Added;

            context.Entry(room1).State = EntityState.Added;
            context.Entry(room2).State = EntityState.Added;
            context.Entry(room3).State = EntityState.Added;
            context.Entry(room4).State = EntityState.Added;
            context.Entry(room5).State = EntityState.Added;
            context.Entry(room6).State = EntityState.Added;

            context.Entry(device1).State = EntityState.Added;
            context.Entry(device2).State = EntityState.Added;
            context.Entry(device3).State = EntityState.Added;
            context.Entry(device4).State = EntityState.Added;

            context.Entry(devicehistory1).State = EntityState.Added;
            context.Entry(devicehistory2).State = EntityState.Added;
            context.Entry(devicehistory3).State = EntityState.Added;

            context.SaveChanges();
        }
       

        
    }
}

using RoomM.Models.Rooms;
using RoomM.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomM.Models.Assets;
using RoomM.Models.Staffs;

namespace RoomM.Model
{
    public class RoomMgrContextCustomInitializer : DropCreateDatabaseAlways<EFDataContext>
    {

        protected override void Seed(EFDataContext context)
        {

            RoomType roomTH = new RoomType { Name = "Thuc hanh tin hoc" };
            RoomType roomBi = new RoomType { Name = "Thuc hanh hoa" };
            RoomType roomPy = new RoomType { Name = "Thuc hanh li" };
            RoomType roomLi = new RoomType { Name = "Thuc hanh li thuyet" };

            HistoryType devicehistorytype1 = new HistoryType { Name = "Chuyen thiet bi" };
            HistoryType devicehistorytype2 = new HistoryType { Name = "Thanh li thiet bi" };

            StaffType usertype1 = new StaffType { Name = "Giang vien" };
            StaffType usertype2 = new StaffType { Name = "Nhan vien quan li thiet bi" };

            RoomCalendarStatus roomcalendarstatus1 = new RoomCalendarStatus { Name = "Cho xac nhan" };
            RoomCalendarStatus roomcalendarstatus2 = new RoomCalendarStatus { Name = "Da dang ki" };
            RoomCalendarStatus roomcalendarstatus3 = new RoomCalendarStatus { Name = "Chua dang ki" };

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

            Asset device1 = new Asset
            {
                Name = "DV001",
            };
            Asset device2 = new Asset
            {
                Name = "DV002",
            };
            Asset device3 = new Asset
            {
                Name = "DV003",
            };
            Asset device4 = new Asset
            {
                Name = "DV004",
            };


            RoomAsset roomD1 = new RoomAsset
            {
                Asset = device1,
                Amount = 10,
                Room = room1
            };

            RoomAsset roomD2 = new RoomAsset
            {
                Asset = device3,
                Amount = 5,
                Room = room1
            };

            RoomAsset roomD3 = new RoomAsset
            {
                Asset = device4,
                Amount = 100,
                Room = room2
            };

            RoomAssetHistory devicehistory1 = new RoomAssetHistory
            {
                Date = new DateTime(2011, 1, 1),
                HistoryType = devicehistorytype1,
                Asset = device3,
                Room = room6,
            };
            RoomAssetHistory devicehistory2 = new RoomAssetHistory
            {
                Date = new DateTime(2011, 1, 3),
                HistoryType = devicehistorytype1,
                Asset = device1,
                Room = room1,
            };
            RoomAssetHistory devicehistory3 = new RoomAssetHistory
            {
                Date = new DateTime(2011, 1, 5),
                HistoryType = devicehistorytype2,
                Asset = device2,
                Room = room2,
            };

            Staff user1 = new Staff
            {
                Name = "adminname",
                Sex = false,
                Phone = "0123456789",
                StaffType = usertype2,
                UserName = "admin",
                PasswordStored = CryptorEngine.Encrypt("admin", true),
                LastLogin = new DateTime(2011, 1, 5),
            };
            Staff user2 = new Staff
            {
                Name = "user2name",
                Sex = true,
                Phone = "0123456790",
                StaffType = usertype1,
                UserName = "user",
                PasswordStored = CryptorEngine.Encrypt("user", true),
                LastLogin = new DateTime(2011, 1, 7),
            };

            RoomCalendar roomcalendar1 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 5),
                Start = 4,
                Length = 2,
                RoomCalendarStatus = roomcalendarstatus1,
                Room = room2,
                Staff = user2
            };

            RoomCalendar roomcalendar2 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 5),
                Start = 10,
                Length = 2,
                RoomCalendarStatus = roomcalendarstatus1,
                Room = room2,
                Staff = user2
            };

            RoomCalendar roomcalendar3 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 7),
                Start = 1,
                Length = 3,
                RoomCalendarStatus = roomcalendarstatus2,
                Room = room1,
                Staff = user1
            };

            RoomCalendar roomcalendar4 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 8),
                Start = 8,
                Length = 4,
                RoomCalendarStatus = roomcalendarstatus1,
                Room = room6,
                Staff = user2
            };

            RoomCalendar roomcalendar5 = new RoomCalendar
            {
                Date = new DateTime(2011, 1, 8),
                Start = 4,
                Length = 2,
                RoomCalendarStatus = roomcalendarstatus2,
                Room = room4,
                Staff = user1
            };

            context.Entry(roomTH).State = EntityState.Added;
            context.Entry(roomBi).State = EntityState.Added;
            context.Entry(roomPy).State = EntityState.Added;
            context.Entry(roomLi).State = EntityState.Added;




            

            context.Entry(devicehistorytype1).State = EntityState.Added;
            context.Entry(devicehistorytype2).State = EntityState.Added;

            context.Entry(roomcalendarstatus1).State = EntityState.Added;
            context.Entry(roomcalendarstatus2).State = EntityState.Added;

            context.Entry(device1).State = EntityState.Added;
            context.Entry(device2).State = EntityState.Added;
            context.Entry(device3).State = EntityState.Added;
            context.Entry(device4).State = EntityState.Added;

            context.Entry(room1).State = EntityState.Added;
            context.Entry(room2).State = EntityState.Added;
            context.Entry(room3).State = EntityState.Added;
            context.Entry(room4).State = EntityState.Added;
            context.Entry(room5).State = EntityState.Added;
            context.Entry(room6).State = EntityState.Added;

            context.Entry(roomD1).State = EntityState.Added;
            context.Entry(roomD2).State = EntityState.Added;
            context.Entry(roomD3).State = EntityState.Added;

            context.Entry(devicehistory1).State = EntityState.Added;
            context.Entry(devicehistory2).State = EntityState.Added;
            context.Entry(devicehistory3).State = EntityState.Added;

            context.Entry(usertype1).State = EntityState.Added;
            context.Entry(usertype2).State = EntityState.Added;

            context.Entry(user1).State = EntityState.Added;
            context.Entry(user2).State = EntityState.Added;

            context.Entry(roomcalendar1).State = EntityState.Added;
            context.Entry(roomcalendar2).State = EntityState.Added;
            context.Entry(roomcalendar3).State = EntityState.Added;
            context.Entry(roomcalendar4).State = EntityState.Added;
            context.Entry(roomcalendar5).State = EntityState.Added;

            context.SaveChanges();
        }
       

        
    }
}

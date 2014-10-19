﻿using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    public class RoomMgrContextCustomInitializer : DropCreateDatabaseAlways<EFDataContext>
    {

        protected override void Seed(EFDataContext context)
        {

            var roomTH = new RoomType { Id = 1, Name = "Thuc hanh tin hoc" };
            var roomBi = new RoomType { Id = 2, Name = "Thuc hanh hoa" };
            var roomPy = new RoomType { Id = 3, Name = "Thuc hanh li" };
            var roomLi = new RoomType { Id = 4, Name = "Thuc hanh li thuyet" };

           

            // context.SaveChanges();

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

            context.RoomTypes.Add(roomTH);
            context.RoomTypes.Add(roomBi);
            context.RoomTypes.Add(roomPy);
            context.RoomTypes.Add(roomLi);

            context.Rooms.Add(room1);
            context.Rooms.Add(room2);

            int i = context.SaveChanges();
            Console.WriteLine("{0} records added...", i);
        }
       

        
    }
}

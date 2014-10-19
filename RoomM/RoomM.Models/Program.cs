using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new RoomMgrContextCustomInitializer());
            using (var db = new EFDataContext())
            {
                db.Database.Initialize(false);

                //int roomTypeId = 1;
                //int roomId = 1;

                //var roomType = new RoomType { Id = roomTypeId, Name = "Thuc hanh tin hoc" };
                //var room = new Room
                //{
                //    Id = roomId,
                //    Name = "A109",
                //    DateCreate = new DateTime(2011, 1, 1),
                //    RoomType = roomType
                //};
                //db.RoomTypes.Add(roomType);
                //db.Rooms.Add(room);
                //Console.WriteLine(db.Database.Connection.ConnectionString);
                //int i = db.SaveChanges();
                //Console.WriteLine("{0} records added...", i);
            }
            Console.WriteLine("Successfully");
            Console.ReadLine();
        }
    }
}

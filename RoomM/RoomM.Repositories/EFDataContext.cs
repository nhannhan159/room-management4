using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories
{
    public class EFDataContext : DbContext
    {
        // connection string:
        private const string connectionString =
            "Data Source=QUOCVU-PC;Initial Catalog=room_mgr;Integrated Security=True";
        public EFDataContext() : base(connectionString) { 
        
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
    }
    public static class StaticRoomContext
    {
        public static EFDataContext Context = new EFDataContext();
    }
}

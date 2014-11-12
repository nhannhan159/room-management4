﻿using RoomM.Model.Rooms;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Model
{
    public class EFDataContext : DbContext
    {
        // connection string:
        private const string connectionString =
            "Data Source=(LocalDB)\v11.0;Initial Catalog=room_mgr;Integrated Security=True";
        public EFDataContext() : base(connectionString) {
        
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAsset> RoomDevices { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            
            // modelBuilder.Entity<Room>().Property(m => m.RoomTypeId).IsOptional();  

            base.OnModelCreating(modelBuilder);
        }
    }

   



    public static class StaticRoomContext
    {
        public static EFDataContext Context = new EFDataContext();
    }
}

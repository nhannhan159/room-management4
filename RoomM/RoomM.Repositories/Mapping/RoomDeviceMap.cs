using RoomM.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Mapping
{
    public class RoomDeviceMap : EntityTypeConfiguration<RoomDevice>
    {
        public RoomDeviceMap() 
        {
            // key
            HasKey(t => t.ID);

            // property
            Property(t => t.RoomId).IsOptional();
            Property(t => t.DeviceId).IsOptional();
            Property(t => t.Amount).IsRequired();

            // table
            ToTable("RoomDevices");

            // replationship
            HasOptional(t => t.Room).WithMany(c => c.RoomDevices)
                .HasForeignKey(t => t.RoomId).WillCascadeOnDelete(true);
            HasOptional(t => t.Device).WithMany(c => c.RoomDevices)
                .HasForeignKey(t => t.DeviceId).WillCascadeOnDelete(true);
            

        }
    }
}

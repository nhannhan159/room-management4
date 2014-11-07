using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RoomM.Models.Devices;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Model.Mapping
{
    public class DeviceHistoryMap : EntityTypeConfiguration<DeviceHistory>
    {
        public DeviceHistoryMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Date);
            Property(t => t.DeviceHistoryTypeId).IsOptional();
            Property(t => t.DeviceId).IsOptional();
            Property(t => t.RoomId).IsOptional();

            // table
            ToTable("DeviceHistorys");

            // relationship
            HasOptional(t => t.DeviceHistoryType).WithMany(c => c.DeviceHistorys)
                .HasForeignKey(t => t.DeviceHistoryTypeId).WillCascadeOnDelete(true);
            HasOptional(t => t.Device).WithMany(c => c.DeviceHistorys)
                .HasForeignKey(t => t.DeviceId).WillCascadeOnDelete(true);
            HasOptional(t => t.Room).WithMany(c => c.DeviceHistorys)
                .HasForeignKey(t => t.RoomId).WillCascadeOnDelete(true);

        }

    }
}

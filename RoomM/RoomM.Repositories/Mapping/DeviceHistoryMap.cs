using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RoomM.Models.Devices;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Repositories.Mapping
{
    public class DeviceHistoryMap : EntityTypeConfiguration<DeviceHistory>
    {
        public DeviceHistoryMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Date).IsRequired();
            Property(t => t.DeviceHistoryTypeId).IsRequired();
            Property(t => t.DeviceId).IsRequired();
            Property(t => t.RoomId).IsRequired();

            // table
            ToTable("DeviceHistorys");

            // relationship
            HasRequired(t => t.DeviceHistoryType).WithMany(c => c.DeviceHistorys)
                .HasForeignKey(t => t.DeviceHistoryTypeId).WillCascadeOnDelete(false);
            HasRequired(t => t.Device).WithMany(c => c.DeviceHistorys)
                .HasForeignKey(t => t.DeviceId).WillCascadeOnDelete(false);
            HasRequired(t => t.Room).WithMany(c => c.DeviceHistorys)
                .HasForeignKey(t => t.RoomId).WillCascadeOnDelete(false);

        }

    }
}

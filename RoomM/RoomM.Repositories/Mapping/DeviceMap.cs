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
    public class DeviceMap : EntityTypeConfiguration<Device>
    {
        public DeviceMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();

            // table
            ToTable("Devices");

            // relationship
            /* HasRequired(t => t.RoomDevices).WithMany(c => c.)
            HasMany(t => t.RoomDevices).WithMany(c => c.Devices)
                                .Map(t => t.ToTable("RoomDevice")
                                    .MapLeftKey("DeviceId")
                                    .MapRightKey("RoomId")); 
            */
        }

    }
}

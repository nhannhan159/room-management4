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
            Property(t => t.IsUsing).IsRequired();

            // table
            ToTable("Devices");

        }

    }
}

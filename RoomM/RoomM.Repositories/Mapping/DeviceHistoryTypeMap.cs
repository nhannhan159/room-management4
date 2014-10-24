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
    public class DeviceHistoryTypeMap : EntityTypeConfiguration<DeviceHistoryType>
    {
        public DeviceHistoryTypeMap()
        { 
            
            // key 
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name);

            // table
            ToTable("DeviceHistoryTypes");
        }

    }
}

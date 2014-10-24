using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RoomM.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Repositories.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            Property(t => t.Sex);
            Property(t => t.Phone);

            // table
            ToTable("Users");

            // relationship
            HasRequired(t => t.UserType).WithMany(c => c.Users)
                .HasForeignKey(t => t.UserTypeId).WillCascadeOnDelete(false);

        }

    }
}

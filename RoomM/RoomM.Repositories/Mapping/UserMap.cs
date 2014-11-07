using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RoomM.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Model.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.UserTypeId).IsOptional();
            Property(t => t.Name).IsRequired();
            Property(t => t.Sex);
            Property(t => t.Phone);
            Property(t => t.UserName).IsRequired();
            Property(t => t.PasswordStored).IsRequired();
            Property(t => t.IsWorking).IsRequired();


            // table
            ToTable("Users");

            // relationship
            HasOptional(t => t.UserType).WithMany(c => c.Users)
                .HasForeignKey(t => t.UserTypeId).WillCascadeOnDelete(true);

        }

    }
}

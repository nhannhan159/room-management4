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
    public class UserAccountMap : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountMap()
        { 
            
            // key 
            HasKey(t => t.ID);

            // properties
            Property(t => t.UserName).IsRequired().HasMaxLength(25);
            Property(t => t.PasswordStored).IsRequired();
            Property(t => t.LastLogin);

            // table
            ToTable("UserAccounts");

            // relationship
            HasRequired(t => t.User).WithRequiredDependent(u => u.UserAccount);  
        }

    }
}

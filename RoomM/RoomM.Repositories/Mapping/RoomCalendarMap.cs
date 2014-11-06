using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RoomM.Models.Rooms;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Model.Mapping
{
    public class RoomCalendarMap : EntityTypeConfiguration<RoomCalendar>
    {
        public RoomCalendarMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Date).IsRequired();
            Property(t => t.Start).IsRequired();
            Property(t => t.Length).IsRequired();
            Property(t => t.RoomId).IsRequired();
            Property(t => t.UserId).IsRequired();
            Property(t => t.RoomCalendarStatusId).IsRequired();

            // table
            ToTable("RoomCalendars");

            // relationship
            HasRequired(t => t.RoomCalendarStatus).WithMany(c => c.RoomCalendars)
                .HasForeignKey(t => t.RoomCalendarStatusId).WillCascadeOnDelete(false);
            HasRequired(t => t.Room).WithMany(c => c.RoomCalendars)
                .HasForeignKey(t => t.RoomId).WillCascadeOnDelete(false);
            HasRequired(t => t.User).WithMany(c => c.RoomCalendars)
                .HasForeignKey(t => t.UserId).WillCascadeOnDelete(false);
        }

    }
}

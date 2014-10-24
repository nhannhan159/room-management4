using RoomM.Models.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Users
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string Phone { get; set; }
        public Int64 UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public UserAccount UserAccount { get; set; }  
    }
}

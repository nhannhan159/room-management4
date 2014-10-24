using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Users
{
    public class UserAccount : EntityBase
    {
        public string UserName { get; set; }
        public string PasswordStored { get; set; }
        [NotMapped]
        public string Password
        {
            get { return CryptorEngine.Decrypt(PasswordStored, true); }
            set { PasswordStored = CryptorEngine.Encrypt(value, true); } 
        }
        public DateTime LastLogin { get; set; }
        public User User { get; set; }  
    }
}

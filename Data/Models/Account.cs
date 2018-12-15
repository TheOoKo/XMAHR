using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

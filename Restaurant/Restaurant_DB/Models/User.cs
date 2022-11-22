using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurant_DB.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public long Key { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurant_DB.Models
{
    public partial class Order
    {
        public long Id { get; set; }
        public long? IdUser { get; set; }
        public long? IdMenuItem { get; set; }
        public string Status { get; set; }
        public int? TableNumber { get; set; }

        public virtual MenuItem IdMenuItemNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}

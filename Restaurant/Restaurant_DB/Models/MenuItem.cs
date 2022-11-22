using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurant_DB.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            Order = new HashSet<Order>();
        }

        public MenuItem(long id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public long Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

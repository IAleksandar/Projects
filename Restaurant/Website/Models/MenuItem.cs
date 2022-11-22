using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class MenuItem
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

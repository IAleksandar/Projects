using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long? IdUser { get; set; }
        public long? IdMenuItem { get; set; }
        public string Status { get; set; }
        public int? TableNumber { get; set; }
    }
}

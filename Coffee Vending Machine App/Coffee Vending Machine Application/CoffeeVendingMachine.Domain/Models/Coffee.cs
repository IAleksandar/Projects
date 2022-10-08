using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeVendingMachine.Domain.Models
{
    public class Coffee : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public List<CoffeeIngridient> Characteristics { get; set; }
        public string ImageLocation { get; set; }
    }
}

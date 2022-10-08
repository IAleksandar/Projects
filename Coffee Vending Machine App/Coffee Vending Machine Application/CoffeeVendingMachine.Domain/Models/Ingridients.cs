using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeVendingMachine.Domain.Models
{
    public class Ingridients : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public List<CoffeeIngridient> Characteristics { get; set; }
    }
}

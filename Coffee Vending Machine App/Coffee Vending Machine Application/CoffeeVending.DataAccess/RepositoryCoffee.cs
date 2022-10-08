using CoffeeVendingMachine.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeVending.DataAccess
{
    public class RepositoryCoffee : IRepository<Coffee>
    {
        private CoffeeVendingMachineDbContext _coffeeVendingMachineDbContext;
        public RepositoryCoffee(CoffeeVendingMachineDbContext coffeeVendingMachineDbContext)
        {
            _coffeeVendingMachineDbContext = coffeeVendingMachineDbContext;
        }
        public List<Coffee> ListCoffees()
        {
            return _coffeeVendingMachineDbContext
               .Coffees
               .Include(x => x.Characteristics)
               .ToList();
        }
    }
}

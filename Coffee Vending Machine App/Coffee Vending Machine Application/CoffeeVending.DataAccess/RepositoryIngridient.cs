using CoffeeVendingMachine.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeVending.DataAccess
{
    public class RepositoryIngridient : IRepository<Ingridients>
    {
        private CoffeeVendingMachineDbContext _coffeeVendingMachineDbContext;
        public RepositoryIngridient(CoffeeVendingMachineDbContext coffeeVendingMachineDbContext)
        {
            _coffeeVendingMachineDbContext = coffeeVendingMachineDbContext;
        }
        public List<Ingridients> ListCoffees()
        {
            return _coffeeVendingMachineDbContext
               .Ingridients
               .Include(x => x.Characteristics)
               .ToList();
        }
    }
}

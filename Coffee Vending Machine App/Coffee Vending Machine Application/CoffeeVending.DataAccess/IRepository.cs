using CoffeeVendingMachine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeVending.DataAccess
{
    public interface IRepository<T>
    {
        List<T> ListCoffees();
    }
}

using CoffeeVending.DataAccess;
using CoffeeVendingMachine.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeVendingMachine.Helpers
{
    public class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<CoffeeVendingMachineDbContext>(options =>
                      options.UseSqlServer("Data Source=ALEKSANDAR\\SQLEXPRESS;Initial Catalog=CoffeeVendingMachineDb;Integrated Security=True")
            );
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Coffee>, RepositoryCoffee>();
            services.AddTransient<IRepository<Ingridients>, RepositoryIngridient>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IRepository<Coffee>, RepositoryCoffee>();
            services.AddTransient<IRepository<Ingridients>, RepositoryIngridient>();
        }
    }
}

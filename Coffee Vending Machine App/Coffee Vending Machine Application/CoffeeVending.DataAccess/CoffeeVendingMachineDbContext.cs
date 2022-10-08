using CoffeeVendingMachine.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeVending.DataAccess
{
    public class CoffeeVendingMachineDbContext : DbContext
    {
        public CoffeeVendingMachineDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Ingridients> Ingridients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coffee>()//table
                .HasMany(x => x.Characteristics) // m side of 1 -m relation
                .WithOne(x => x.Coffee) // 1 side of 1 -m relation
                .HasForeignKey(x => x.IngridientId); //FK

            modelBuilder.Entity<Ingridients>()
                .HasMany(x => x.Characteristics)
                .WithOne(x => x.Ingridients)
                .HasForeignKey(x => x.CoffeeId);

            modelBuilder.Entity<Coffee>()
                .HasData(new Coffee
                {
                    Id = 1,
                    Name = "Latte",
                    Price = 5,
                    ImageLocation = "~/img/latte_01.jpg"
                },
                new Coffee
                {
                    Id = 2,
                    Name = "Macchiato",
                    Price = 6,
                    ImageLocation = "~/img/macchiato_01.jpg"
                },
                new Coffee
                {
                    Id = 3,
                    Name = "Esspresso",
                    Price = 4,
                    ImageLocation = "~/img/espresso_01.jpg"
                },
                new Coffee
                {
                    Id = 4,
                    Name = "Americano",
                    Price = 7,
                    ImageLocation = "~/img/americano_01.jpg"
                },
                new Coffee
                {
                    Id = 5,
                    Name = "Irish",
                    Price = 10,
                    ImageLocation = "~/img/irish_01.jpg"
                }
                );


            modelBuilder.Entity<Ingridients>()
                .HasData(new Ingridients
                {
                    Id = 1,
                    Name = "Sugar",
                    Price= 0
                },
                new Ingridients
                {
                    Id = 2,
                    Name = "Creamer",
                    Price = 2
                },
                new Ingridients
                {
                    Id = 3,
                    Name = "Caramelle",
                    Price = 3
                },
                new Ingridients
                {
                    Id = 4,
                    Name = "More milk",
                    Price = 4
                },
                new Ingridients
                {
                    Id = 5,
                    Name = "has a single dose of milk",
                    Price = 3
                },
                new Ingridients
                {
                    Id = 6,
                    Name = "one pack of sugar",
                    Price = 0
                }
                );
        }
    }
}

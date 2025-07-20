using Gazprom.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gazprom.API.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Offer> Offers { get; set; }
    public DbSet<Supplier> Supplier { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var suppliers = new List<Supplier>
        {
            new Supplier
            {
                Id = 1,
                Name = "Toyota",
                CreatedDate = new DateTime(1937, 8, 28)
            },
            new Supplier
            {
                Id = 2,
                Name = "Samsung",
                CreatedDate = new DateTime(1938, 3, 1)
            },
            new Supplier
            {
                Id = 3,
                Name = "Apple",
                CreatedDate = new DateTime(1976, 4, 1)
            },
            new Supplier
            {
                Id = 4,
                Name = "Microsoft",
                CreatedDate = new DateTime(1975, 4, 4)
            },
            new Supplier
            {
                Id = 5,
                Name = "Sony",
                CreatedDate = new DateTime(1946, 5, 7)
            }
        };
        modelBuilder.Entity<Supplier>().HasData(suppliers);

        var offers = new List<Offer>
        {
            new Offer
            {
                Id = 1,
                SupplierId = 1,
                Mark = "Toyota",
                Model = "Camry",
                RegistrationDate = new DateTime(2023, 1, 15)
            },
            new Offer
            {
                Id = 2,
                SupplierId = 1,
                Mark = "Toyota",
                Model = "RAV4",
                RegistrationDate = new DateTime(2023, 2, 20)
            },
            new Offer
            {
                Id = 3,
                SupplierId = 2,
                Mark = "Samsung",
                Model = "Galaxy S23",
                RegistrationDate = new DateTime(2023, 3, 1)
            },
            new Offer
            {
                Id = 4,
                SupplierId = 3,
                Mark = "Apple",
                Model = "iPhone 14",
                RegistrationDate = new DateTime(2023, 1, 10)
            },
            new Offer
            {
                Id = 5,
                SupplierId = 3,
                Mark = "Apple",
                Model = "MacBook Pro",
                RegistrationDate = new DateTime(2023, 2, 5)
            },
            new Offer
            {
                Id = 6,
                SupplierId = 4,
                Mark = "Microsoft",
                Model = "Surface Pro 9",
                RegistrationDate = new DateTime(2023, 3, 10)
            },
            new Offer
            {
                Id = 7,
                SupplierId = 5,
                Mark = "Sony",
                Model = "PlayStation 5",
                RegistrationDate = new DateTime(2023, 1, 25)
            },
            new Offer
            {
                Id = 8,
                SupplierId = 5,
                Mark = "Sony",
                Model = "WH-1000XM5",
                RegistrationDate = new DateTime(2023, 2, 15)
            }
        };
        modelBuilder.Entity<Offer>().HasData(offers);
        base.OnModelCreating(modelBuilder);
    }
}
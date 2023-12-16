using BlazorServer.FacadePatternExample.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.FacadePatternExample.Infrastructure
{
    public class FacadePatternContext : DbContext
    {
        public FacadePatternContext(DbContextOptions<FacadePatternContext> options) : base(options)
        {
            
        }

        DbSet<ShippingProvider> shippingProviders => Set<ShippingProvider>();
        DbSet<Customer> Customers => Set<Customer>();
        DbSet<Genre> Genres => Set<Genre>();
        DbSet<Author> Authors => Set<Author>();
        DbSet<Book> Books => Set<Book>();
        DbSet<BookOrder> BookOrders => Set<BookOrder>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShippingProvider>().HasData(
                new ShippingProvider { Id = 1, Description = "United States Postal Service", IsActive = true, Name = "USPS"},
                new ShippingProvider { Id = 2, Description = "United Postal Service", IsActive = true, Name = "UPS"},
                new ShippingProvider { Id = 3, Description = "Fedex", IsActive = true, Name = "FEDEX"}
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Address = "123 Fake St", Country = "USA", CustomerSince =  new DateTime(2000, 1, 1), Description = "None", IsActive = true, Name = "Fred" }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Description = "Fiction", IsActive = true, Name = "Fiction" },
                new Genre { Id = 2, Description = "Romantic", IsActive = true, Name = "Romantic" },
                new Genre { Id = 3, Description = "Sci-Fi", IsActive = true, Name = "Sci-Fi" }
            );
        }
    }
}

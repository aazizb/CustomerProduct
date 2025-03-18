using CustomerProduct.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CustomerProduct.Persistence
{
    public class CustomerProductDbContext : DbContext
    {
        public CustomerProductDbContext(DbContextOptions<CustomerProductDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id); // primary Key

                entity.Property(c => c.DocType)
                      .IsRequired(); // required field

                entity.HasIndex(c => c.CustomerId)
                      .IsUnique(); // Unique constraint
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(c => c.Id); // primary Key

                entity.Property(c => c.ProductName)
                      .IsRequired(); // required field

                entity.HasIndex(c => c.CustomerId)
                      .IsUnique(); // Unique constraint
            });

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Customer)  // Product has one Customer
                .WithOne(c => c.Product)  // Customer has one Product
                .HasForeignKey<Product>(p => p.CustomerId) // Product.CustomerId is FK
                .HasPrincipalKey<Customer>(c => c.CustomerId); // CustomerId is unique key

            base.OnModelCreating(modelBuilder);
        }

    }
}

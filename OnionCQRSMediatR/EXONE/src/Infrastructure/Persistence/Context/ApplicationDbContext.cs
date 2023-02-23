using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Code = "Product Code 1", Name = "Product Name 1", Price = 10 },
                new Product() { Id = Guid.NewGuid(), Code = "Product Code 2", Name = "Product Name 2", Price = 90 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = new Guid(), Code = "Product Code 1", Name = "Product Name 1", Price = 10 },
                new Product() { Id = new Guid(), Code = "Product Code 2", Name = "Product Name 2", Price = 90 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

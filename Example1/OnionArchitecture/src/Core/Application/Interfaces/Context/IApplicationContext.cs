using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
    }
}

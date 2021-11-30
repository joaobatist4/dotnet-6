using Dotnet6.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.Context;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
}


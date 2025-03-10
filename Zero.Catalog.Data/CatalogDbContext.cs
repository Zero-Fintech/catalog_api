using Microsoft.EntityFrameworkCore;
using Zero.Catalog.Data.Entities;

namespace Zero.Catalog.Data;

public class CatalogDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
     : base(options)
    {

    }
}
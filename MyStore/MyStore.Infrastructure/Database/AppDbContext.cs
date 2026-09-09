using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;

namespace MyStore.Infrastructure.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext>options):DbContext(options)
    {
        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<SaleDetail> SaleDetail { get; set; }
    }
}

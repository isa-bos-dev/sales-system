using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Infrastructure.Database;

namespace MyStore.Infrastructure.Repositories
{
    public class SaleRepository(AppDbContext _dbcontext) : ISaleRepository
    {

        public async Task<IEnumerable<Sale>> GetAsync(DateOnly startDate, DateOnly endDate)
        {
            return await _dbcontext.Sale
               .Where(s => DateOnly.FromDateTime(s.CreatedAt) >= startDate
               && DateOnly.FromDateTime(s.CreatedAt) <= endDate)
               .Include(u => u.User)
               .ToListAsync();
        }

        public async Task<Sale?> GetByIdAsync(int id)
        {
            return await _dbcontext.Sale
                .Include(u => u.User)
                .Include(sd=> sd.SaleDetails)
                .ThenInclude(p=>p.Product)
                .FirstOrDefaultAsync(s=>s.SaleId == id);
        }

        public async Task AddAsync(Sale sale)
        {
            using var transaction = await _dbcontext.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in sale.SaleDetails)
                {
                    var product = await _dbcontext.Product.FindAsync(item.ProductId);
                    product!.Stock -= item.Quantity;
                }
                await _dbcontext.Sale.AddAsync(sale);
                await _dbcontext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Infrastructure.Database;

namespace MyStore.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext _dbcontext) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _dbcontext.Product.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByParameterAsync(string parameter)
        {
            return await _dbcontext.Product
               .Where(p => p.SKU.Contains(parameter) || p.Name.Contains(parameter)).ToListAsync();
        }


        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbcontext.Product.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddAsync(Product product)
        {
            await _dbcontext.AddAsync(product);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(Product product)
        {
            _dbcontext.Product.Update(product);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _dbcontext.Product.FindAsync(id);
            _dbcontext.Product.Remove(product);
            await _dbcontext.SaveChangesAsync();
        }
    }
}

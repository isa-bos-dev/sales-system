using MyStore.Domain.Entities;

namespace MyStore.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();

        // Searches by SKU or name
        Task<IEnumerable<Product>> GetByParameterAsync(string parameter);

        // Returns null when no product matches the id
        Task<Product?> GetByIdAsync(int id);

        Task AddAsync(Product product);

        Task EditAsync(Product product);

        Task DeleteAsync(int id);
    }
}

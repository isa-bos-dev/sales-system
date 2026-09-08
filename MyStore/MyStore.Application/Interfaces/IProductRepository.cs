using MyStore.Domain.Entities;

namespace MyStore.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();

        Task<Product?> GetByParameterAsync(string parameter);

        Task<Product?> GetByIdAsync(int id);

        Task AddAsync(Product product);

        Task EditAsync(Product product);

        Task DeleteAsync(int id);
    }
}

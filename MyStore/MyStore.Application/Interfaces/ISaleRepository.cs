using MyStore.Domain.Entities;

namespace MyStore.Application.Interfaces
{
    public interface ISaleRepository
    {
        // Both dates are included in the range
        Task<IEnumerable<Sale>> GetAsync(DateOnly startDate, DateOnly endDate);

        // Returns the sale with its details, or null when no sale matches the id
        Task<Sale?> GetByIdAsync(int id);

        // Saves the sale and discounts the stock of the products sold
        Task AddAsync(Sale sale);
    }
}

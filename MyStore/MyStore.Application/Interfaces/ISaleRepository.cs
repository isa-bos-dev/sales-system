using MyStore.Domain.Entities;

namespace MyStore.Application.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAsync(DateOnly startDate, DateOnly endDate);

        Task<Sale?> GetByIdAsync(int id);

        Task AddAsync(Sale sale);
    }
}

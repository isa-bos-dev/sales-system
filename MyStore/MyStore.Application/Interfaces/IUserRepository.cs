using MyStore.Domain.Entities;

namespace MyStore.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();

        Task<User?> GetByIdAsync(int Id);

        Task<User?> LoginAsync(string Email, string Password);

        Task AddAsync(User user);

        Task EditAsync(User user);

        Task DeleteAsync(int id);

    }
}

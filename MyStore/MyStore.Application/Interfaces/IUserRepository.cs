using MyStore.Domain.Entities;

namespace MyStore.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();

        // Returns null when no user matches the id
        Task<User?> GetByIdAsync(int id);

        // Returns null when the credentials do not match any user
        Task<User?> LoginAsync(string email, string password);

        Task AddAsync(User user);

        Task EditAsync(User user);

        Task DeleteAsync(int id);

    }
}

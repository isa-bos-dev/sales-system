using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Infrastructure.Database;

namespace MyStore.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext _dbcontext) : IUserRepository
    {

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _dbcontext.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbcontext.User.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            return await _dbcontext.User.
                FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task AddAsync(User user)
        {
            await _dbcontext.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync(User user)
        {
            _dbcontext.User.Update(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _dbcontext.User.FindAsync(id);
            _dbcontext.User.Remove(user);
            await _dbcontext.SaveChangesAsync();
        }
    }
}

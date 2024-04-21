using BarberShopProject.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberShopProject.Infrastructure.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<bool> AddUser(User user);

    }
    public class UsersRepository : IUsersRepository
    {
        private readonly BarberShopContext _context;
        public UsersRepository(BarberShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Set<User>().ToListAsync();
        }

        public async Task<bool> AddUser(User user)
        {
            await _context.Set<User>().AddAsync(user);
            var res = await _context.SaveChangesAsync();
            if (res != null)
            {
                return true;

            }
            else { return false; }
        }
    }
}

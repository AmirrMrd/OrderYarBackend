using BarberShopProject.Infrastructure.Entities;
using BarberShopProject.Infrastructure.Repositories;

namespace BarberShopProject.Services.Authorization
{
    public interface IAuthorizationService
    {
        Task<bool> AddUser(User user);
    }
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUsersRepository _usersRepository;
        public AuthorizationService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<bool> AddUser(User user)
        {
            await _usersRepository.AddUser(user);
           return true;
        }
    }
}

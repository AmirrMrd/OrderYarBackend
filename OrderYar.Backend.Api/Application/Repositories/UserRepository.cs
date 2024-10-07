using OrderYar.Backend.Api.Infrastructure.Data;
using OrderYar.Backend.Api.Infrastructure.Interface;

namespace OrderYar.Backend.Api.Application.Repositories;

public class UserRepository(ApplicationDbContext context) : GenericRepository<User>(context), IUserRepository
{
}

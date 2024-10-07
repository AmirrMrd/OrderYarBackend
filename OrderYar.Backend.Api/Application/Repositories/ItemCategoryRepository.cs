using OrderYar.Backend.Api.Infrastructure.Data;
using OrderYar.Backend.Api.Infrastructure.Interface;

namespace OrderYar.Backend.Api.Application.Repositories;

public class ItemCategoryRepository(ApplicationDbContext context) : GenericRepository<ItemCategory>(context), IItemCategoryRepository
{
}

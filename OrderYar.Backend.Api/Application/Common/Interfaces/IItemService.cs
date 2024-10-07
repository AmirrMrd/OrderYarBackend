using OrderYar.Backend.Api.Application.Common.Models;
using OrderYar.Backend.Api.Application.Common.Models.Items;

namespace OrderYar.Backend.Api.Application.Common.Interfaces;

public interface IItemService
{
    Task<Pagination<Item>> Get(int pageIndex, int pageSize);
    Task<Item> Get(int id);
    Task Add(ItemDTO request, CancellationToken token);
    Task Update(Item request, CancellationToken token);
    Task Delete(int id, CancellationToken token);
}

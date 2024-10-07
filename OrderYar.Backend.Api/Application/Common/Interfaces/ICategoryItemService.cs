using OrderYar.Backend.Api.Application.Common.Models.Items;
using OrderYar.Backend.Api.Application.Common.Models;
using OrderYar.Backend.Api.Application.Common.Models.CategoryItem;

namespace OrderYar.Backend.Api.Application.Common.Interfaces;

public interface ICategoryItemService
{
    Task<Pagination<ItemCategory>> Get(int pageIndex, int pageSize);
    Task<ItemCategory> Get(int id);
    Task Add(ItemCategoryDTO request, CancellationToken token);
    Task Update(ItemCategory request, CancellationToken token);
    Task Delete(int id, CancellationToken token);
}

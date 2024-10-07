using OrderYar.Backend.Api.Application.Common.Interfaces;
using OrderYar.Backend.Api.Application.Common.Models.CategoryItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderYar.Backend.Api.Web.Controller.CategoryItem;

public class ItemCategoryController(ICategoryItemService ItemCategoryService) : BaseController
{
    private readonly ICategoryItemService _itemCategoryService = ItemCategoryService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await _itemCategoryService.Get(id));

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get(int pageIndex = 0, int pageSize = 10)
        => Ok(await _itemCategoryService.Get(pageIndex, pageSize));

    [HttpPost]
    public async Task<IActionResult> Add(ItemCategoryDTO request, CancellationToken token)
    {
        await _itemCategoryService.Add(request, token);
        return NoContent();
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update(ItemCategory request, CancellationToken token)
    {
        await _itemCategoryService.Update(request, token);
        return NoContent();
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await _itemCategoryService.Delete(id, token);
        return NoContent();
    }
}

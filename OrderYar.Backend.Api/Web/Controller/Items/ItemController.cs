using OrderYar.Backend.Api.Application.Common.Interfaces;
using OrderYar.Backend.Api.Application.Common.Models.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderYar.Backend.Api.Web.Controller.Items;

public class ItemController(IItemService ItemService) : BaseController
{
    private readonly IItemService _itemService = ItemService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await _itemService.Get(id));

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get(int pageIndex = 0, int pageSize = 10)
        => Ok(await _itemService.Get(pageIndex, pageSize));

    [HttpPost]
    public async Task<IActionResult> Add(ItemDTO request, CancellationToken token)
    {
        await _itemService.Add(request, token);
        return NoContent();
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update(Item request, CancellationToken token)
    {
        await _itemService.Update(request, token);
        return NoContent();
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await _itemService.Delete(id, token);
        return NoContent();
    }
}

using AutoMapper;
using OrderYar.Backend.Api.Application.Common.Interfaces;
using OrderYar.Backend.Api.Application.Common.Models;
using OrderYar.Backend.Api.Application.Common.Models.Items;

namespace OrderYar.Backend.Api.Application.Services;

public class ItemService(IUnitOfWork unitOfWork, IMapper mapper) : IItemService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Pagination<Item>> Get(int pageIndex, int pageSize)
    {
        var items = await _unitOfWork.ItemRepository.ToPagination(pageIndex, pageSize);
        return items;
    }

    public async Task<Item> Get(int id)
    {
        var items = await _unitOfWork.ItemRepository.FirstOrDefaultAsync(x => x.Id == id);
        return items;
    }

    public async Task Add(ItemDTO request, CancellationToken token)
    {
        var item = _mapper.Map<Item>(request);
        await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.ItemRepository.AddAsync(item), token);
    }
    public async Task Update(Item request, CancellationToken token)
    {
        var item = await _unitOfWork.ItemRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.ItemRepository.Update(item), token);
    }
    public async Task Delete(int id, CancellationToken token)
    {
        var item = await _unitOfWork.ItemRepository.FirstOrDefaultAsync(x => x.Id == id);
        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.ItemRepository.Delete(item), token);
    }
}

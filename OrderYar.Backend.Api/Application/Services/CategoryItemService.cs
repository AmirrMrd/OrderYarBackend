using AutoMapper;
using OrderYar.Backend.Api.Application.Common.Interfaces;
using OrderYar.Backend.Api.Application.Common.Models;
using OrderYar.Backend.Api.Application.Common.Models.CategoryItem;


namespace OrderYar.Backend.Api.Application.Services;

public class CategoryItemService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryItemService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Pagination<ItemCategory>> Get(int pageIndex, int pageSize)
    {
        var items = await _unitOfWork.ItemCategoryRepository.ToPagination(pageIndex, pageSize);
        return items;
    }

    public async Task<ItemCategory> Get(int id)
    {
        var itemCategory = await _unitOfWork.ItemCategoryRepository.FirstOrDefaultAsync(x => x.Id == id);
        return itemCategory;
    }

    public async Task Add(ItemCategoryDTO request, CancellationToken token)
    {
        var itemCategory = _mapper.Map<ItemCategory>(request);
        await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.ItemCategoryRepository.AddAsync(itemCategory), token);
    }
    public async Task Update(ItemCategory request, CancellationToken token)
    {
        var itemCategory = await _unitOfWork.ItemCategoryRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.ItemCategoryRepository.Update(itemCategory), token);
    }
    public async Task Delete(int id, CancellationToken token)
    {
        var itemCategory = await _unitOfWork.ItemRepository.FirstOrDefaultAsync(x => x.Id == id);
        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.ItemCategoryRepository.Delete(itemCategory), token);
    }
}

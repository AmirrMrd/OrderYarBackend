using AutoMapper;
using OrderYar.Backend.Api.Application.Common.Models.CategoryItem;
using OrderYar.Backend.Api.Application.Common.Models.Items;
using OrderYar.Backend.Api.Application.Common.Models.User;

namespace OrderYar.Backend.Api.Application.Common.Mappings;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<User, UserSignInRequest>().ReverseMap();
        CreateMap<User, UserSignInResponse>().ReverseMap();
        CreateMap<User, UserSignUpRequest>().ReverseMap();
        CreateMap<User, UserSignUpResponse>().ReverseMap();
        CreateMap<User, UserProfileResponse>().ReverseMap();

        // Item
        CreateMap<Item, ItemDTO>()
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.ItemCategory.CategoryName));

        CreateMap<ItemDTO, Item>();

        // ItemCategory
        CreateMap<ItemCategory, ItemCategoryDTO>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName));

        CreateMap<ItemCategoryDTO, ItemCategory>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName));
    }
}

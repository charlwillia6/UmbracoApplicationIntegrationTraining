using AutoMapper;
using onlineStoreDb;
using Training.Mvc.OnlineStore.UI.Areas.AdminPanel.ViewModels;
using Training.Mvc.OnlineStore.UI.Helpers;
using Training.Mvc.OnlineStore.UI.Models;
using Training.Mvc.OnlineStore.UI.ViewModels;

namespace Training.Mvc.OnlineStore.UI.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            
            Mapper.CreateMap<Product, ProductBasicViewModel>();
            
            Mapper.CreateMap<Product, ProductPreviewViewModel>()
                .ForMember(x => x.PreviewImageUrl, source => source.MapFrom(src => MediaHelper.GetPreviewImage(src.Id)))
                .ForMember(x => x.CarouselImageUrl, source => source.MapFrom(src => MediaHelper.GetCarouselImage(src.Id)));

            Mapper.CreateMap<Product, ShoppingCartProductPreviewViewModel>();

            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.PreviewImageUrl, source => source.MapFrom(src => MediaHelper.GetPreviewImage(src.Id)))
                .ForMember(x => x.CarouselImageUrl, source => source.MapFrom(src => MediaHelper.GetCarouselImage(src.Id)))
                .ForMember(x => x.DetailsImageUrl, source => source.MapFrom(src => MediaHelper.GetDetailsImage(src.Id)));

            Mapper.CreateMap<Product, CartItem>()
                .ForMember(x => x.ProductId, source => source.MapFrom(src => src.Id));

            Mapper.CreateMap<AddOrEditCategoryViewModel, Category>();
            Mapper.CreateMap<AddOrEditProductViewModel, Product>()
                .ForMember(x => x.Category, source => source.MapFrom(src => src.CategoryId));
        }
    }
}
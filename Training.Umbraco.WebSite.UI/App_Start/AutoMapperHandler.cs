using AutoMapper;
using onlineStoreDb;
using Training.Umbraco.WebSite.UI.ViewModels;
using Training.Umbraco.WebSite.UI.Helpers;
using Training.Umbraco.WebSite.UI.Models;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Training.Umbraco.WebSite.UI
{
    public class AutoMapperHandler
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Product, ProductBasicViewModel>();

            Mapper.CreateMap<Product, ProductPreviewViewModel>()
                .ForMember(x => x.PreviewImageUrl, source => source.MapFrom(src => "/content/images/" + src.Id + ".jpg?width=200&height=200"))
                .ForMember(x => x.CarouselImageUrl, source => source.MapFrom(src => "/content/images/" + src.Id + ".jpg?width=600&height=200&mode=crop&anchor=top"));

            Mapper.CreateMap<Product, ShoppingCartProductPreviewViewModel>();

            Mapper.CreateMap<Product, ProductViewModel>()
               .ForMember(x => x.ImageUrl, source => source.MapFrom(src => "/content/images/" + src.Id + ".jpg?width=400&height=400"));


            Mapper.CreateMap<Product, CartItem>()
                .ForMember(x => x.ProductId, source => source.MapFrom(src => src.Id));


            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Category, CategoryBasicViewModel>();
        }
    }
}
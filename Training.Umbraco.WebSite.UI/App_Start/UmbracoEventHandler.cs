using AutoMapper;
using onlineStoreDb;
using Training.Services.OnlineStore.Concretes;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;

namespace Training.Umbraco.WebSite.UI
{
    public class UmbracoEventHandler
    {
        internal static void Delete(global::Umbraco.Core.Services.IContentService sender, DeleteEventArgs<IContent> e)
        {
            e.DeletedEntities.ForEach(Delete);
        }

        internal static void Save(global::Umbraco.Core.Publishing.IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            e.PublishedEntities.ForEach(AddOrSave);
        }

        private static void Delete(IContent e)
        {
            switch (e.ContentType.Alias)
            {
                case "Product":
                    break;
            }
        }

        private static void AddOrSave(IContent e)
        {
            
            if (e.ContentType.Alias == "Product")
            {
                var productService = new PetaPocoProductService("umbracoDbDSN");
                var pocoObj = Mapper.Map<Product>(e);
                var product = productService.GetById(e.Id);

                if (product == null)
                {
                    productService.Add(pocoObj);
                }
                else
                {
                    productService.Update(pocoObj);
                }
            }

            if (e.ContentType.Alias == "Category")
            {
                var categoryService = new PetaPocoCategoryService("umbracoDbDSN");
                var pocoObj = new Category() {Id = e.Id, Name = e.Name};
                var category = categoryService.GetById(e.Id);

                if (category == null)
                {
                    categoryService.Add(pocoObj);
                }
                else
                {
                    categoryService.Update(pocoObj);
                }
            }
        }
    }
}
using System.Collections.Generic;
using onlineStoreDb;
using Training.Services.OnlineStore.Models;

namespace Training.Services.OnlineStore.Interfaces
{
    public interface IProductService
    {
        int Add(Product product);

        void Update(Product product);

        void Delete(Product product);

        void Delete(int id);

        IEnumerable<Product> GetAll(ProductSearchFilter productSearchFilter);

        IEnumerable<Product> GetAll(ProductSearchFilter productSearchFilter, out int totalItems, int page = 1, int pageSize = 20);

        Product GetById(int id);

        IEnumerable<Product> GetTopSelling(int count);

        IEnumerable<Product> GetFeatured(int count);

        IEnumerable<Product> GetTopRated(int count);

        IEnumerable<Product> Search(string q, ProductSearchFilter productSearchFilter, out int totalItems, int page = 1, int pageSize = 20);
    }
}

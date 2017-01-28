using System.Collections.Generic;
using onlineStoreDb;

namespace Training.Services.OnlineStore.Interfaces
{
    public interface ICategoryService
    {
        int Add(Category category);

        void Update(Category product);

        void Delete(Category product);

        void Delete(int id);

        IEnumerable<Category> GetAll(bool excludeCategoryWithNoProducts = false);

        IEnumerable<Category> GetAll(out int totalItems, int page = 1, int pageSize = 20, bool excludeCategoryWithNoProducts = false);

        Category GetById(int id);
    }
}

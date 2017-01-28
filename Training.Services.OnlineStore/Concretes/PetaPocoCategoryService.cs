using System.Collections.Generic;
using onlineStoreDb;
using PetaPoco;
using Training.Services.OnlineStore.Interfaces;

namespace Training.Services.OnlineStore.Concretes
{
    public class PetaPocoCategoryService : ICategoryService
    {
        #region Fields

        private Database PetaPocoDb { get; set; }

        #endregion

        #region Constructors

        public PetaPocoCategoryService(string connectionStringName)
        {
            PetaPocoDb = new Database(connectionStringName);
        }

        #endregion

        #region Methods

        public int Add(Category category)
        {
            return int.Parse(PetaPocoDb.Insert("Category","Id", false, category).ToString());
        }

        public void Update(Category category)
        {
            PetaPocoDb.Update(category);
        }

        public void Delete(Category category)
        {
            PetaPocoDb.Delete(category);
        }

        public void Delete(int id)
        {
            PetaPocoDb.Delete<Category>(id);
        }

        public IEnumerable<Category> GetAll(bool excludeCategoryWithNoProducts = false)
        {
            int temp;
            return GetAll(out temp, 1, int.MaxValue, excludeCategoryWithNoProducts);
        }

        public IEnumerable<Category> GetAll(out int totalItems, int page = 1, int pageSize = 20, bool excludeCategoryWithNoProducts = false)
        {
            var mainSql = new Sql();

            var innerSql = new Sql();
            innerSql.Append("SELECT DISTINCT c.* FROM Category c");

            if (excludeCategoryWithNoProducts)
            {
                innerSql.Append("Right JOIN Product p ON p.Category = c.Id");
            }

            mainSql.Append(string.Format("SELECT * FROM ({0}) as Cat", innerSql.ToString()));
            mainSql.Append("ORDER BY Cat.NAME");

            var categoriesPaged = PetaPocoDb.Page<Category>(page, pageSize, mainSql);
            totalItems = (int)categoriesPaged.TotalItems;
            return categoriesPaged.Items;

        }

        public Category GetById(int id)
        {
            return PetaPocoDb.SingleOrDefault<Category>(id);
        }

        #endregion
    }
}

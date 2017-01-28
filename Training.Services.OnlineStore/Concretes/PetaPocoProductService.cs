using System.Collections.Generic;
using onlineStoreDb;
using PetaPoco;
using Training.Services.OnlineStore.Interfaces;
using Training.Services.OnlineStore.Models;

namespace Training.Services.OnlineStore.Concretes
{
    public class PetaPocoProductService : IProductService
    {
        #region Fields

        private Database PetaPocoDb { get; set; }

        #endregion

        #region Constructors

        public PetaPocoProductService(string connectionStringName)
        {
            PetaPocoDb = new Database(connectionStringName);
        }

        #endregion

        #region Methods

        public int Add(Product product)
        {
            return int.Parse(PetaPocoDb.Insert("Product", "Id", false, product).ToString());
        }

        public void Update(Product product)
        {
            PetaPocoDb.Update(product);
        }

        public void Delete(Product product)
        {
            PetaPocoDb.Delete(product);
        }

        public void Delete(int id)
        {
            PetaPocoDb.Delete<Product>(id);
        }

        public IEnumerable<Product> GetAll(ProductSearchFilter productSearchFilter)
        {
            return PetaPocoDb.Fetch<Product>(GetAllSqlStatement(productSearchFilter));
        }

        public IEnumerable<Product> GetAll(ProductSearchFilter productSearchFilter, out int totalItems, int page = 1, int pageSize = 20)
        {
            var productsPaged = PetaPocoDb.Page<Product>(page, pageSize, GetAllSqlStatement(productSearchFilter));
            totalItems = (int) productsPaged.TotalItems;
            return productsPaged.Items;
        }

        public Product GetById(int id)
        {
            return PetaPocoDb.SingleOrDefault<Product>(id);
        }

        public IEnumerable<Product> GetTopSelling(int count)
        {
            var sql = new Sql();
            sql.Append(string.Format("SELECT TOP {0} * FROM Product", count));
            sql.Append("ORDER BY Price DESC");

            return PetaPocoDb.Fetch<Product>(sql.ToString());
        }

        public IEnumerable<Product> GetFeatured(int count)
        {
            var sql = new Sql();
            sql.Append(string.Format("SELECT TOP {0} * FROM Product", count));
            sql.Append("WHERE HpFeatured=@0", 1);
            sql.Append("ORDER BY Price ASC");

            return PetaPocoDb.Fetch<Product>(sql);
        }

        public IEnumerable<Product> GetTopRated(int count)
        {
            var sql = new Sql();
            sql.Append(string.Format("SELECT TOP {0} * FROM Product", count));
            sql.Append("ORDER BY Rates DESC");

            return PetaPocoDb.Fetch<Product>(sql.ToString());
        }

        public IEnumerable<Product> Search(string q, ProductSearchFilter productSearchFilter, out int totalItems, int page = 1, int pageSize = 20)
        {
            var sql = new Sql()
                .Append("SELECT p.*")
                .Append("FROM Product p")
                .Append("JOIN Category c ON c.Id = p.Category");

            sql.Append("WHERE p.Name LIKE @0", string.Format("%{0}%", q));

            if (productSearchFilter != null && productSearchFilter.CategoryId.HasValue)
            {
                sql.Append("WHERE p.Category=@0", productSearchFilter.CategoryId);
            }

            sql.Append("OR p.Summary LIKE @0", string.Format("%{0}%", q));
            sql.Append("OR p.Description LIKE @0", string.Format("%{0}%", q));
            sql.Append("OR c.Name LIKE @0", string.Format("%{0}%", q));

            AppendSqlOrderStatement(sql, productSearchFilter);
            sql.Append("ORDER BY p.HpFeatured");


            var productsPaged = PetaPocoDb.Page<Product>(page, pageSize, sql);
            totalItems = (int)productsPaged.TotalItems;
            return productsPaged.Items;
        }

        #endregion

        #region Helpers

        private static Sql GetAllSqlStatement(ProductSearchFilter productSearchFilter)
        {
            var sql = new Sql();
            sql.Append("SELECT p.* FROM Product p");

            if (productSearchFilter != null)
            {
                if (productSearchFilter.CategoryId.HasValue)
                {
                    sql.Append("WHERE p.Category=@0", productSearchFilter.CategoryId.Value);
                }

                AppendSqlOrderStatement(sql, productSearchFilter);
            }

            return sql;
        }

        private static void AppendSqlOrderStatement(Sql sql, ProductSearchFilter productSearchFilter)
        {
            if (productSearchFilter == null)
            {
                return;
            }

            switch (productSearchFilter.SortBy)
            {
                case ProductSortBy.NameAsc:
                    sql.Append("ORDER BY p.Name ASC");
                    break;

                case ProductSortBy.PriceHighest:
                    sql.Append("ORDER BY p.Price DESC");
                    break;

                case ProductSortBy.PriceLowest:
                    sql.Append("ORDER BY p.Price ASC");
                    break;

                case ProductSortBy.RateHighest:
                    sql.Append("ORDER BY p.Rates DESC");
                    break;

                case ProductSortBy.RateLowest:
                    sql.Append("ORDER BY p.Rates ASC");
                    break;
                default:
                    sql.Append("ORDER BY p.Name DESC");
                    break;
            }
        }

        #endregion
    }
}

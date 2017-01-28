namespace Training.Services.OnlineStore.Models
{
    public class ProductSearchFilter
    {
        public ProductSearchFilter()
        {
            SortBy = ProductSortBy.NameDesc;
        }

        public int? CategoryId { get; set; }

        public ProductSortBy SortBy { get; set; }
    }
}

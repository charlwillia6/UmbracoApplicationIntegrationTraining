using System.Collections.Generic;
using Training.Mvc.OnlineStore.UI.Models.Interfaces;

namespace Training.Mvc.OnlineStore.UI.Models
{
    public class Pager<T> : IPager
    {
        public Pager(IEnumerable<T> items, int totalItems, int page, int pageSize = 20, string urlFormat = "")
        {
            Items = items;
            TotalItems = totalItems;
            Page = page;
            PageSize = pageSize;
            UrlFormat = urlFormat;
        }

        public IEnumerable<T> Items { get; private set; }

        public int TotalItems { get; private set; }

        public int Page { get; private set; }

        public int PageSize { get; private set; }

        public int TotalPages
        {
            get
            {
                return TotalItems % PageSize == 0 ? TotalItems / PageSize : TotalItems / PageSize + 1;
            }
        }

        public bool ShowNextPage {
            get { return TotalItems > Page*PageSize; }
        }

        public bool ShowPrevPage
        {
            get { return Page > 1; }
        }

        public bool OnlyOnePage {
            get { return TotalItems <= PageSize; }
        }

        public string UrlFormat { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Training.Umbraco.WebSite.UI.Models;
using Training.Services.OnlineStore.Models;
using Training.Umbraco.WebSite.UI.Extensions;
using Umbraco.Web.Models;
using Umbraco.Core.Models;

namespace Training.Umbraco.WebSite.UI.ViewModels
{
    public class ListOfProductsPreviewViewModel 
    {
        public ListOfProductsPreviewViewModel(ProductSortBy sortBy = ProductSortBy.RateHighest)
        {
            var list = Enum.GetValues(typeof (ProductSortBy)).Cast<ProductSortBy>().ToList();
            ProductSortByList = list
                .Select(x => new SelectListItem() {Text = x.GetCustomAttribute<DescriptionAttribute>(x.ToString()).Description, Value = ((int) x).ToString(), Selected = x == sortBy}).ToList();
        }

        public Pager<ProductPreviewViewModel> List { get; set; }

        public string ListTitle { get; set; }

        public IEnumerable<SelectListItem> ProductSortByList { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Training.Mvc.OnlineStore.UI.Extensions;
using Training.Mvc.OnlineStore.UI.Models;
using Training.Services.OnlineStore.Models;

namespace Training.Mvc.OnlineStore.UI.ViewModels
{
    public class ListOfProductsViewModel : BaseViewModel
    {
        public ListOfProductsViewModel(ProductSortBy sortBy = ProductSortBy.RateHighest)
        {
            var list = Enum.GetValues(typeof (ProductSortBy)).Cast<ProductSortBy>().ToList();
            ProductSortByList = list
                .Select(x => new SelectListItem() {Text = x.GetCustomAttribute<DescriptionAttribute>(x.ToString()).Description, Value = ((int) x).ToString(), Selected = x == sortBy}).ToList();
        }

        public Pager<ProductViewModel> List { get; set; }

        public string ListTitle { get; set; }

        public IEnumerable<SelectListItem> ProductSortByList { get; set; }
    }
}
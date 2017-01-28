using System.ComponentModel;

namespace Training.Services.OnlineStore.Models
{
    public enum ProductSortBy
    {
        [Description("Name (Desc)")]
        NameDesc,
        [Description("Name (Asc)")]
        NameAsc,

        [Description("Price (Desc)")]
        PriceHighest,

        [Description("Price (Asc)")]
        PriceLowest,

        [Description("Rate (Desc)")]
        RateHighest,
        
        [Description("Rate (Asc)")]
        RateLowest
    }
}
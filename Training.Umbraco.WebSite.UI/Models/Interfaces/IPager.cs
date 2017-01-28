namespace Training.Umbraco.WebSite.UI.Models.Interfaces
{
    public interface IPager
    {
        int TotalItems { get; }

        int Page { get; }

        int PageSize { get; }

        int TotalPages { get; }

        bool ShowNextPage { get; }

        bool ShowPrevPage { get; }

        bool OnlyOnePage { get; }

        string UrlFormat { get; }
    }
}

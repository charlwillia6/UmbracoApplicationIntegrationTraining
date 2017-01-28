using Umbraco.Web;
using Umbraco.Web.Routing;

namespace Training.Umbraco.WebSite.UI.ContentFinders
{
    public class FindContentByFormerUrl : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            // read in the path from the PublishedContentRequest
            var path = contentRequest.Uri.AbsolutePath;

            // find any published item with a formerUrl matching the path
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var matchingContent = umbracoHelper.TypedContentSingleAtXPath("//TextPage[formerUrl/text() = '" + path + "']");

            if (matchingContent == null)
            {
                // return false, there is no matching content
                return false;
            }

            //contentRequest.PublishedContent = matchingContent;
            contentRequest.SetRedirectPermanent(matchingContent.Url);
            return true;
        }
    }
}
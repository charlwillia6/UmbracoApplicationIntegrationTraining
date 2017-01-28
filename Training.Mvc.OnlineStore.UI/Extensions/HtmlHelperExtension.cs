using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Training.Mvc.OnlineStore.UI.Extensions
{
    public static class HtmlHelperExtension
    {
        public static string SingularOrPluralText(this HtmlHelper src, int count, string singularText, string pluralText)
        {
            return count > 1 ? pluralText : singularText;
        }

        public static string SingularOrPluralText<T>(this HtmlHelper src, IEnumerable<T> collection, string singularText, string pluralText)
        {
            return SingularOrPluralText(src, collection == null ? 0 : collection.Count(), singularText, pluralText);
        }

        public static string AppendQueryStringItem(this HtmlHelper src, string url, string key, string value)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            var existingQueryStringKey = query.AllKeys.FirstOrDefault(x => x.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            if (existingQueryStringKey == null)
            {
                query.Add(key, value);
            }
            else
            {
                query[existingQueryStringKey] = value;
            }

            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }
    }
}
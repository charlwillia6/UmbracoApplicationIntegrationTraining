using AutoMapper;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Training.Umbraco.WebSite.UI.Helpers
{
    public class UmbracoPropertyResolver<T> : ValueResolver<Content, T>
    {
        private readonly string _propertyAlias;

        public UmbracoPropertyResolver(string propertyAlias)
        {
            _propertyAlias = propertyAlias;
        }

        protected override T ResolveCore(Content source)
        {
            return source.GetValue<T>(_propertyAlias);
        }
    }

    public class UmbracoPublishContentPropertyResolver<T> : ValueResolver<IPublishedContent, T>
    {
        private readonly string _propertyAlias;

        public UmbracoPublishContentPropertyResolver(string propertyAlias)
        {
            _propertyAlias = propertyAlias;
        }

        protected override T ResolveCore(IPublishedContent source)
        {
            return source.GetPropertyValue<T>(_propertyAlias);
        }
    }
}

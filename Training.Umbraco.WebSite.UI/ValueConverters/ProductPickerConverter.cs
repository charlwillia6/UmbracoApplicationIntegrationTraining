using Newtonsoft.Json;
using onlineStoreDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.Services.OnlineStore.Concretes;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace Training.Umbraco.WebSite.UI.ValueConverters
{
    [PropertyValueType(typeof(IEnumerable<Product>))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class ProductPickerConverter : PropertyValueConverterBase
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("store.productpicker");
        }

        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
                return null;

            var array = JsonConvert.DeserializeObject<int[]>((string)source);
            var ps = new PetaPocoProductService("onlineStoreDb");

            return array.Select(x => ps.GetById(x)).Where(x => x != null);
        }
    }
}
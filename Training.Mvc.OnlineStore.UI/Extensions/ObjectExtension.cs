using System.Linq;

namespace Training.Mvc.OnlineStore.UI.Extensions
{
    public static class ObjectExtension
    {
        public static T GetCustomAttribute<T>(this object src, string propertyName)
        {
            var field = src.GetType().GetField(propertyName);
            return (T)field.GetCustomAttributes(typeof(T), true).FirstOrDefault();
        }
    }
}
using System.Collections.Specialized;

namespace Ignition.Core.Extensions
{
    public class GlassExtensions
    {
        public static NameValueCollection CssClass(string cssClass)
        {
            return new NameValueCollection { { "class", cssClass } };
        }

        public static NameValueCollection Image(string cssClass, int height, int width)
        {
            return new NameValueCollection { { "class", cssClass }, { "height", height.ToString() }, { "width", width.ToString() } };
        }

        public static NameValueCollection Attribute(string attributeName, string attributeValue)
        {
            return new NameValueCollection { { attributeName, attributeValue } };
        }
    }
}

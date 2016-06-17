using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Ignition.Core.HtmlHelpers
{
    public interface IGlassRenderHelper
    {
        NameValueCollection CssClasses(string item);
        NameValueCollection CssClasses(IEnumerable<string> items);
        NameValueCollection Image(string cssClass, int height, int width);
        NameValueCollection Attributes(string attributeName, string attributeValue);
        NameValueCollection Attributes(IEnumerable<Tuple<string,string>> attributes);
    }
}

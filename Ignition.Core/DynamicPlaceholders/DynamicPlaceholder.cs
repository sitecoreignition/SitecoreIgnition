//Code credit to Stack Overflow user Dunston - http://stackoverflow.com/questions/15134720/sitecore-dynamic-placeholders-with-mvc

using System.Web;
using Sitecore.Mvc.Presentation;

namespace Ignition.Foundation.Core.DynamicPlaceholders
{
    public static class SitecoreHelper
    {
        public static HtmlString DynamicPlaceholder(this Sitecore.Mvc.Helpers.SitecoreHelper helper, string dynamicKey)
        {
            return helper.Placeholder($"{dynamicKey}_{RenderingContext.Current.Rendering.UniqueId}");
        }
    }
}

//Code credit to Stack Overflow user Dunston - http://stackoverflow.com/questions/15134720/sitecore-dynamic-placeholders-with-mvc

using System.Web;
using Sitecore.Mvc.Presentation;

namespace Ignition.Core.HtmlHelpers
{
    public static class SitecoreHelper
    {
        public static HtmlString DynamicPlaceholder(this Sitecore.Mvc.Helpers.SitecoreHelper helper, string dynamicKey)
        {
            var currentRenderingId = RenderingContext.Current.Rendering.UniqueId;
            return helper.Placeholder($"{dynamicKey}_{currentRenderingId}");
        }
    }
}

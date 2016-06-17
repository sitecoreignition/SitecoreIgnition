using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Ignition.Core.HtmlHelpers
{
    public static class HtmlHelperExtension
    {
        /// <summary>
        ///     Use to add Resources like JS or CSS to bottom of Layout.
        /// </summary>
        /// <param name="htmlHelper">Current HtmlHelper</param>
        /// <param name="template">Func to add to HelperResult</param>
        /// <param name="type">The ResourceType selected</param>
        /// <returns>MvcHtmlString</returns>
        public static MvcHtmlString RegisterResource(this HtmlHelper htmlHelper, Func<object, HelperResult> template,
            String type)
        {
            if (htmlHelper.ViewContext.HttpContext.Items[type] != null)
            {
                //htmlHelper.ViewContext.HttpContext.Items.Cast<object>()
                //    .Where(item => ReferenceEquals(item, template)).ForEach(a=>HttpContext.Current.Response.Write("Hef"));
                ((List<Func<object, HelperResult>>) htmlHelper.ViewContext.HttpContext.Items[type]).Add(template);
            }
            else
            {
                var value = new List<Func<object, HelperResult>> {template};
                htmlHelper.ViewContext.HttpContext.Items[type] = value;
            }
            return new MvcHtmlString(String.Empty);
        }

        /// <summary>
        ///     Use this to render content added in a View (using
        ///     Resource) to the bottom of Layout.
        /// </summary>
        /// <param name="htmlHelper">Current HtmlHelper</param>
        /// <param name="type">The ResourceType selected</param>
        /// <returns>MvcHtmlString</returns>
        public static MvcHtmlString RenderResources(this HtmlHelper htmlHelper, string type)
        {
            if (htmlHelper.ViewContext.HttpContext.Items[type] == null) return new MvcHtmlString(String.Empty);
            var resources = (List<Func<object, HelperResult>>) htmlHelper.ViewContext.HttpContext.Items[type];
            foreach (var resource in resources.Where(resource => resource != null))
            {
                htmlHelper.ViewContext.Writer.Write("\n{0}", resource(null));
            }
            return new MvcHtmlString(String.Empty);
        }
    }
}
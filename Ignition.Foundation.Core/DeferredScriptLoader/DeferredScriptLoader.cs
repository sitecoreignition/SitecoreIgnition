using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Ignition.Foundation.Core.DeferredScriptLoader
{
    public static class DeferredScriptLoader
    {
	    private const string Type = "js";
		/// <summary>
		///     Use to add JS or CSS to bottom of Layout.
		/// </summary>
		/// <param name="htmlHelper">Current HtmlHelper</param>
		/// <param name="template">Func to add to HelperResult</param>
		/// <returns>MvcHtmlString</returns>
		public static MvcHtmlString RegisterScriptBlock(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        {

            if (htmlHelper.ViewContext.HttpContext.Items[Type] != null)
            {
                ((List<Func<object, HelperResult>>) htmlHelper.ViewContext.HttpContext.Items[Type]).Add(template);
            }
            else
            {
                var value = new List<Func<object, HelperResult>> {template};
                htmlHelper.ViewContext.HttpContext.Items[Type] = value;
            }
            return new MvcHtmlString(string.Empty);
        }

        /// <summary>
        ///     Use this to render content added in a View (using
        ///     Resource) to the bottom of Layout.
        /// </summary>
        /// <param name="htmlHelper">Current HtmlHelper</param>
        /// <returns>MvcHtmlString</returns>
        public static MvcHtmlString RenderScriptBlocks(this HtmlHelper htmlHelper)
        {
            if (htmlHelper.ViewContext.HttpContext.Items[Type] == null) return new MvcHtmlString(string.Empty);
            var resources = (List<Func<object, HelperResult>>) htmlHelper.ViewContext.HttpContext.Items[Type];
            foreach (var resource in resources.Where(resource => resource != null))
            {
                htmlHelper.ViewContext.Writer.Write("\n{0}", resource(null));
            }
            return new MvcHtmlString(string.Empty);
        }
    }
}
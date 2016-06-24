using System.Collections.Specialized;

namespace Ignition.Core.HtmlHelpers
{
	public class GlassHelper
	{
		public static object CssClass(string cssClass)
		{
			return new { @class = cssClass };
		}

		public static object Image(string cssClass, int height, int width)
		{
			return new { @class = cssClass, height = height.ToString(), width = width.ToString() };
		}

		public static NameValueCollection Attribute(string attributeName, string attributeValue)
		{
			return new NameValueCollection { { attributeName, attributeValue } };
		}
	}
}

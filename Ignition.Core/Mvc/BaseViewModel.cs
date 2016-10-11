using System.Collections.Specialized;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Mvc
{
    public class BaseViewModel
    {
        public virtual string ViewPath { get; set; }
        public IPage ContextPage { get; set; }
        public string ParentPlaceholderName { get; set; }
        public bool UseWrapper { get; set; }
		public object CssClass(string cssClass) => new { @class = cssClass };
	    public object Image(string cssClass, int height, int width) => new { @class = cssClass, height = height.ToString(), width = width.ToString() };
	    public NameValueCollection Attribute(string attributeName, string attributeValue) => new NameValueCollection { { attributeName, attributeValue } };
    }
}
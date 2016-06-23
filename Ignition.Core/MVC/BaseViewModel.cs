using Ignition.Core.Models.Page;

namespace Ignition.Core.Mvc
{
    public class BaseViewModel
    {
        public virtual string ViewPath { get; set; }
        public IPage ContextPage { get; set; }
        public string ParentPlaceholderName { get; set; }
        public bool UseWrapper { get; set; }
    }
}
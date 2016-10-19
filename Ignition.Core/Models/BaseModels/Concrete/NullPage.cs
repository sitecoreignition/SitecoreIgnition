using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.Page;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Foundation.Core.Models.BaseModels.Concrete
{
    public class NullPage : NullModel, IPage
    {
        public string PageTitle { get; set; } = string.Empty;
        public string PageDescription { get; set; } = string.Empty;
        public string NavigationTitle { get; set; } = string.Empty;
        public bool HideFromNavigation { get; set; } = true;
        public bool HideChildrenFromNavigation { get; set; } = true;
        public Link OverrideLink { get; set; } = null;
        public bool ShowMore { get; set; } = false;
        public IEnumerable<IOption> Tags { get; set; } = Enumerable.Empty<IOption>();
    }
}
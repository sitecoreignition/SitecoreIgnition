using System.Collections.Generic;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.News
{
    public class FeaturedNewsViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }

        public IEnumerable<IFeaturedNewsItem> FeatureNewsItems { get; set; }

        public IFeaturedNews EditFrameItem { get; set; }
    }
}
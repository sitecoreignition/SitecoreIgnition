using System.Collections.Generic;
using Ignition.Core.Mvc;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.News
{
    public class FeaturedNewsViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }

        public IEnumerable<IFeaturedNewsItem> FeatureNewsItems { get; set; }
    }
}
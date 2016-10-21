using System.Collections.Generic;
using Ignition.Feature.News.Models;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.News.ViewModels
{
    public class FeaturedNewsViewModel : IgnitionViewModel
    {
        public IHeading Heading { get; set; }

        public IEnumerable<IFeaturedNewsItem> FeatureNewsItems { get; set; }

        public IFeaturedNews EditFrameItem { get; set; }
    }
}
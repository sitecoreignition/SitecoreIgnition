using System.Collections.Generic;
using Ignition.Feature.News.Models;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.News.ViewModels
{
    public class LatestNewsViewModel : IgnitionViewModel
    {
        public IHeading Heading { get; set; }

        public IEnumerable<ILatestNewsItem> LatestNewsItems { get; set; }

        public ILatestNews EditFrameItem { get; set; }
    }
}
using System.Collections.Generic;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.News
{
    public class LatestNewsViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }

        public IEnumerable<ILatestNewsItem> LatestNewsItems { get; set; }

        public ILatestNews EditFrameItem { get; set; }
    }
}
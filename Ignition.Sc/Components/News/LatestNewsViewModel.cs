using System.Collections.Generic;
using Ignition.Core.Mvc;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.News
{
    public class LatestNewsViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }

        public IEnumerable<ILatestNewsItem> LatestNewsItems { get; set; }
    }
}
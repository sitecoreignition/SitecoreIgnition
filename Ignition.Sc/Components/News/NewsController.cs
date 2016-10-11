using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.News
{
    public class NewsController : IgnitionController
    {
        public ActionResult NewsGrid() => View<NewsGridViewModel>();

        public ActionResult FeaturedNews() => View<FeaturedNewsAgent, FeaturedNewsViewModel>();

        public ActionResult LatestNews() => View<LatestNewsAgent, LatestNewsViewModel>();
    }
}
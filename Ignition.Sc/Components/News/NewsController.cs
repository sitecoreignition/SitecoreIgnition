using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.News
{
    public class NewsController : IgnitionController
    {
        public ActionResult FeaturedNews() => View<FeaturedNewsAgent, FeaturedNewsViewModel>();

        public ActionResult NewsGrid() => View<NewsGridViewModel>();
    }
}
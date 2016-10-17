using System.Web.Mvc;
using Ignition.Feature.News.Agents;
using Ignition.Feature.News.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.News.Controllers
{
    public class NewsController : IgnitionController
    {
        public ActionResult NewsGrid() => View<NewsGridViewModel>();

        public ActionResult FeaturedNews() => View<FeaturedNewsAgent, FeaturedNewsViewModel>();

        public ActionResult LatestNews() => View<LatestNewsAgent, LatestNewsViewModel>();
    }
}
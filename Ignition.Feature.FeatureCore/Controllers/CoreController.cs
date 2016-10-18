using System.Web.Mvc;
using Ignition.Feature.Core.Agents;
using Ignition.Feature.Core.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.Core.Controllers
{
    public class CoreController : IgnitionController
    {
        public ActionResult Header() => View<HeaderAgent, HeaderViewModel>();
	    public ActionResult Footer() => View<BaseViewModel>();
	    public ActionResult FooterScript() => View<BaseViewModel>();
	    public ActionResult Breadcrumb() => View<BreadcrumbViewModel>();
		public ActionResult IgnitionFrame() => View<FrameViewModel>();
    }
}

using System.Web.Mvc;
using Ignition.Feature.Structure.Agents;
using Ignition.Feature.Structure.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.Structure.Controllers
{
    public class StructureController : IgnitionController
    {
        public ActionResult Header() => View<HeaderAgent, HeaderViewModel>();
	    public ActionResult Footer() => View<BaseViewModel>();
	    public ActionResult FooterScript() => View<BaseViewModel>();
	    public ActionResult Breadcrumb() => View<BreadcrumbViewModel>();
		public ActionResult IgnitionFrame() => View<FrameViewModel>();
    }
}

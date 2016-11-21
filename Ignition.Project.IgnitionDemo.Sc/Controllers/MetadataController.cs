using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;
using IgnitionController = Ignition.Foundation.Core.Mvc.IgnitionController;

namespace Ignition.Project.IgnitionDemo.Sc.Controllers
{
    public class MetadataController : IgnitionController
    {
        public ActionResult Head() => View<IgnitionViewModel>();

	    public ActionResult Metadata() => View<IgnitionViewModel>();

	    public ActionResult Script()
        {
            return View<IgnitionViewModel>();
        }
        public ActionResult Seo()
        {
            return View<IgnitionViewModel>();
        }
        public ActionResult Style()
        {
            return View<IgnitionViewModel>();
        }
        public ActionResult Taxonomy()
        {
            return View<IgnitionViewModel>();
        }
        public ActionResult Analytics()
        {
            return View<IgnitionViewModel>();
        }

        public ActionResult PageEdit()
        {
            return View<IgnitionViewModel>();
        }
    }
}
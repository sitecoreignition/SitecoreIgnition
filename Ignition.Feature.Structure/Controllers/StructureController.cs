using System.Web.Mvc;
using Ignition.Feature.Structure.Agents;
using Ignition.Feature.Structure.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.Structure.Controllers
{
    public class StructureController : IgnitionController
    {
        public ActionResult Header()
        {
            return View<HeaderAgent, HeaderViewModel>();
        }

        public ActionResult Footer()
        {
            return View<BaseViewModel>();
        }

        public ActionResult FooterScript()
        {
            return View<BaseViewModel>();
        }
    }
}

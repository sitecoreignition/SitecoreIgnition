using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Bookends
{
    public class BookendsController : IgnitionController
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

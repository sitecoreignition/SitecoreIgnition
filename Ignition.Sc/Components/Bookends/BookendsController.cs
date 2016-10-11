using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Bookends
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

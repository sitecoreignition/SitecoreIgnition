using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.Ignition.Bookends
{
    public class BookendsController : IgnitionController
    {
        public BookendsController(ItemContext context) : base(context)
        {
        }

        public ActionResult Header()
        {
            return GetViewResult<BaseViewModel>();
        }

        public ActionResult Footer()
        {
            return GetViewResult<BaseViewModel>();
        }

        public ActionResult FooterScript()
        {
            return GetViewResult<BaseViewModel>();
        }
    }
}

using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.Ignition.Frame
{
    public class FrameController : BaseController
    {
        public FrameController(ItemContext context) : base(context)
        {
        }

        public ActionResult IgnitionFrame()
        {
            return GetViewResult<FrameViewModel>();
        }

    }
}

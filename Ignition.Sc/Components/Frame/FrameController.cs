using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Frame
{
    public class FrameController : IgnitionController
    {
        public ActionResult IgnitionFrame()
        {
            return View<FrameViewModel>();
        }

	    public ActionResult FiftyFiftyFrame()
	    {
		    return View<FrameViewModel>();
	    }

    }
}

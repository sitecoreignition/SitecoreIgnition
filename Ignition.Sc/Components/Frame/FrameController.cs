using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Frame
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

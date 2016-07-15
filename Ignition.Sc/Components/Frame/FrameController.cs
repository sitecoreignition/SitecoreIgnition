using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.Frame
{
    public class FrameController : IgnitionController
    {
        public FrameController(AgentContext agentContext) : base(agentContext)
        {
        }

        public ActionResult IgnitionFrame()
        {
            return View<FrameViewModel>();
        }

    }
}

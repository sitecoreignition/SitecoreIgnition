﻿using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.Frame
{
    public class FrameController : IgnitionController
    {
        public FrameController(ItemContext context) : base(context)
        {
        }

        public ActionResult IgnitionFrame()
        {
            return View<FrameViewModel>();
        }

    }
}

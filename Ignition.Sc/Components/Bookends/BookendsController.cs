﻿using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.Bookends
{
    public class BookendsController : IgnitionController
    {
        public BookendsController(AgentContext agentContext) : base(agentContext)
        {
        }

        public ActionResult Header()
        {
            return View<BaseViewModel>();
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

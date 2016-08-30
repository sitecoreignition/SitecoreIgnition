using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Service
{
    public class ServiceController : IgnitionController
    {
        public ActionResult ServiceGrid() => View<ServiceAgent, ServiceGridViewModel>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.About
{
    public class AboutController : IgnitionController
    {
        public ActionResult AboutPeopleGrid() => View<AboutPeopleGridViewModel>();

        public ActionResult AboutPeopleTile() => View<AboutPeopleTileViewModel>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.Hero
{
    public class HeroController : IgnitionController
    {
        public ActionResult AboutHero() => View<AboutHeroAgent, AboutHeroViewModel>();
    }
}
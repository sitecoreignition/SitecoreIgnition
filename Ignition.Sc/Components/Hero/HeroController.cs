using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Hero
{
    public class HeroController : IgnitionController
    {
        public ActionResult AboutHero() => View<AboutHeroAgent, AboutHeroViewModel>();
    }
}
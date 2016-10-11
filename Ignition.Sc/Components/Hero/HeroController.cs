using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Hero
{
    public class HeroController : IgnitionController
    {
        public ActionResult AboutHero() => View<AboutHeroAgent, AboutHeroViewModel>();
    }
}
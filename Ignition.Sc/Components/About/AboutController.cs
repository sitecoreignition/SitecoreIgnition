using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.About
{
    public class AboutController : IgnitionController
    {
        public ActionResult AboutPeopleGrid() => View<AboutPeopleGridViewModel>();

        public ActionResult AboutPeopleTile() => View<AboutPeopleTileViewModel>();
    }
}
using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.About
{
    public class AboutController : IgnitionController
    {
        public ActionResult AboutPeopleGrid() => View<AboutPeopleGridViewModel>();

        public ActionResult AboutPeopleTile() => View<AboutPeopleTileViewModel>();
    }
}
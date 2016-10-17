using System.Web.Mvc;
using Ignition.Feature.Content.Agents;
using Ignition.Feature.Content.ViewModels;
using Ignition.Foundation.Core.Mvc;


namespace Ignition.Feature.Content.Controllers
{
	public class ContentController: IgnitionController
	{
		public ActionResult AboutPeopleGrid() => View<AboutPeopleGridViewModel>();
		public ActionResult AboutPeopleTile() => View<AboutPeopleTileViewModel>();
		public ActionResult AboutHero() => View<AboutHeroAgent, AboutHeroViewModel>();
		public ActionResult FullWidthContent() => null;
	}
}
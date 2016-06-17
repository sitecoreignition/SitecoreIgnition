using System.Linq;
using System.Web.Mvc;
using Ignition.Core.Mvc.ViewEngines;
using Sitecore.Pipelines;

namespace Ignition.Root.App_Start
{
	public class InitializeViewEngines
	{
		public void Process(PipelineArgs args)
		{
			RegisterViewEngines(ViewEngines.Engines);
		}

		public static void RegisterViewEngines(ViewEngineCollection viewEngines)
		{
			viewEngines.Insert(0, new FrameworkConventionsViewEngine());

			var razorViewEngines = viewEngines.OfType<RazorViewEngine>().Reverse();
			foreach (var razorViewEngine in razorViewEngines)
			{
				viewEngines.Insert(0, new ExperienceEditorViewEngine(razorViewEngine));
			}
		}
	}
}

using System.Linq;
using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;
using Sitecore.Pipelines;

namespace Ignition.Project.CompositionRoot
{
	public class InitializeViewEngines
	{
		public void Process(PipelineArgs args)
		{
			RegisterViewEngines(ViewEngines.Engines);
		}

		public static void RegisterViewEngines(ViewEngineCollection viewEngines)
		{
			var razorViewEngines = viewEngines.OfType<RazorViewEngine>().Reverse();
			foreach (var razorViewEngine in razorViewEngines)
			{
				viewEngines.Insert(0, new ExperienceEditorViewEngine(razorViewEngine));
			}
		}
	}
}

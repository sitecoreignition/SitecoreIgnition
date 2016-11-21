using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Ignition.Foundation.Core.Mvc
{
	public class ExperienceEditorViewEngine : IViewEngine
	{
		private readonly RazorViewEngine _viewEngine;

		public ExperienceEditorViewEngine(RazorViewEngine viewEngine)
		{
			_viewEngine = viewEngine;
		}

		public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
		{
			return !IsExperienceEditorMode() ? NullViewEngineResult() :
			  _viewEngine.FindPartialView(controllerContext, GetExperienceEditorViewName(partialViewName), false);
		}

		public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
		{
			return !IsExperienceEditorMode() ? NullViewEngineResult() :
			  _viewEngine.FindView(controllerContext, GetExperienceEditorViewName(viewName), masterName, false);
		}

		public void ReleaseView(ControllerContext controllerContext, IView view)
		{
			_viewEngine.ReleaseView(controllerContext, view);
		}

		private static bool IsExperienceEditorMode()
		{
			return Sitecore.Context.PageMode.IsExperienceEditor;
		}

		private static ViewEngineResult NullViewEngineResult()
		{
			return new ViewEngineResult(Enumerable.Empty<string>());
		}

		private static string GetExperienceEditorViewName(string viewName)
		{
		    return IsApplicationRelativePath(viewName) ? Regex.Replace(viewName, @"^(.*)\.(cshtml)$", "$1.EE.$2") : $"{viewName}.EE";
		}

	    private static bool IsApplicationRelativePath(string viewName)
		{
			return viewName[0] == '~' || viewName[0] == '/';
		}
	}
}

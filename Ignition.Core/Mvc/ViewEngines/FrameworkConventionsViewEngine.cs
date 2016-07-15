using System.Web.Mvc;

namespace Ignition.Core.Mvc.ViewEngines
{
	public class FrameworkConventionsViewEngine : RazorViewEngine
	{
		private readonly string[] _areaViewConventions =
		{
			"~/Areas/{2}/Components/{1}/{0}.cshtml"
		};

		private readonly string[] _viewConventions =
		{
			"~/Components/{1}/{0}.cshtml"
		};

		public FrameworkConventionsViewEngine()
		{
			AreaViewLocationFormats = _areaViewConventions;
			AreaMasterLocationFormats = _areaViewConventions;
			AreaPartialViewLocationFormats = _areaViewConventions;

			ViewLocationFormats = _viewConventions;
			MasterLocationFormats = _viewConventions;
			PartialViewLocationFormats = _viewConventions;

			FileExtensions = new[] { "cshtml" };
		}
	}
}

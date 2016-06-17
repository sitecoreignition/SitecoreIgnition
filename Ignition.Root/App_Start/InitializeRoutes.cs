using System.Web.Mvc;
using System.Web.Routing;
using Ignition.Core.Mvc.Routing;
using Sitecore.Pipelines;

namespace Ignition.Root.App_Start
{
	public class InitializeRoutes
	{
		public virtual void Process(PipelineArgs args)
		{
			RegisterRoutes(RouteTable.Routes);
		}

		public bool MvcIgnoreHomePage { get; set; }

		protected virtual void RegisterRoutes(RouteCollection routes)
		{
			if (MvcIgnoreHomePage) { routes.IgnoreRoute(string.Empty); }
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapMvcAttributeRoutes(new PublicRouteProvider("ignitionapi"));
		}
	}
}

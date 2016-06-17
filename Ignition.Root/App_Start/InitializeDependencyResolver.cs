using System.Web.Mvc;
using Castle.Windsor;
using Ignition.Core.Factories;
using Ignition.Core.Installers;
using Ignition.Sc;
using Sitecore.Pipelines;

namespace Ignition.Root.App_Start
{
	public class InitializeDependencyResolver
	{
		public void Process(PipelineArgs args)
		{
			RegisterDependencyResolver(args);
		}

		public static void RegisterDependencyResolver(PipelineArgs args)
		{
			var container = CreateWindsorContainer();
			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
		}

		private static IWindsorContainer CreateWindsorContainer()
		{
			var container = new WindsorContainer();
			container.Install(new SitecoreInstaller());
			container.Install(new CoreInstaller());
			container.Install(new IgnitionScInstaller());
			container.Install(new RootInstaller());
			return container;
		}
	}
}

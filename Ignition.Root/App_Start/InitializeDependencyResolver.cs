using System;
using System.Linq;
using System.Web.Mvc;
using Ignition.Foundation.Core.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Sitecore.Pipelines;

namespace Ignition.Project.CompositionRoot
{
	public class InitializeDependencyResolver
	{
		public void Process(PipelineArgs args)
		{
			RegisterDependencyResolver(args);
		}

		public static void RegisterDependencyResolver(PipelineArgs args)
		{
			var container = CreateSimpleInjectorContainer();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}

		private static Container CreateSimpleInjectorContainer()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
			container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();
            container.Options.ConstructorResolutionBehavior = new MostResolvableConstructorBehavior(container);
            container.RegisterMvcIntegratedFilterProvider();
			container.RegisterPackages(AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Ignition")));

			container.Verify();
			return container;
		}
	}
	
}

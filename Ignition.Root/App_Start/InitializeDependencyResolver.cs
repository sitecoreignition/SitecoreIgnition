using System;
using System.Linq;
using System.Web.Mvc;
using Glass.Mapper;
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
			//Load referenced assemblies
			container.RegisterPackages(System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(System.Reflection.Assembly.Load));
			//load possible standalone assemblies
			//TODO: Add code here
			container.Verify();
			return container;
		}
	}
	
}

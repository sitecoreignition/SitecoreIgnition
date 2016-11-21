using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Ignition.Foundation.Core.Attributes;
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
			var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
			//load possible standalone assemblies
			assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies()
					.Where(assembly => assembly.GetCustomAttributes(typeof(IgnitionAutomapAttribute)).Any())
					.Where(a=>!assemblies.Contains(a))
					.Select(a => Assembly.Load(a.FullName)));
			container.RegisterPackages(assemblies);
			container.Verify();
			return container;
		}
	}
	
}

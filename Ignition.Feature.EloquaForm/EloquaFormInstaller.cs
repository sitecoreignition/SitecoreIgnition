using System;
using System.Reflection;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Core.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Ignition.Feature.EloquaForm
{
	public class EloquaFormInstaller : IPackage
	{
		public void RegisterServices(Container container)
		{
			var assembly = Assembly.GetExecutingAssembly();
			container.RegisterMvcControllers(assembly);
			container.RegisterAllConcreteTypesFor(typeof(Agent<>), assembly, Lifestyle.Transient);
		}
	}
}

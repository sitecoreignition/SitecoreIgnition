using System.Reflection;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Core.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Ignition.Feature.News
{
	public class IgnitionNewsInstaller : IPackage
	{
		public void RegisterServices(Container container)
		{
			var assembly = Assembly.GetExecutingAssembly();
			container.RegisterMvcControllers(assembly);
			container.RegisterAllConcreteTypesFor(typeof(Agent<>), assembly, Lifestyle.Transient);
		}
	}
}

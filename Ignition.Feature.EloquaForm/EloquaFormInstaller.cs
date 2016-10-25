using System.ComponentModel;
using System.Reflection;
using Ignition.Foundation.Core.Mvc;

namespace _FeatureTemplate
{
	public class IgnitionFeatureCoreInstaller : IPackage
	{
		public void RegisterServices(Container container)
		{
			var assembly = Assembly.GetExecutingAssembly();
			container.RegisterMvcControllers(assembly);
			container.RegisterAllConcreteTypesFor(typeof(Agent<>), assembly, Lifestyle.Transient);
		}
	}
}

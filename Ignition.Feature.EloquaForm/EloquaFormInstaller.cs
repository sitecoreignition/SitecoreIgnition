using System.Reflection;

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

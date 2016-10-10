using Ignition.Core.Mvc;
using Ignition.Core.SimpleInjector;
using SimpleInjector;

namespace Ignition.Sc
{
	public class IgnitionScInstaller : SimpleInjectorInstaller
	{
		public override void Install(Container container)
		{
			container.RegisterMvcControllers(ThisAssembly);
			container.RegisterAllConcreteTypesFor(typeof(Agent<>), ThisAssembly, Lifestyle.Transient);
		}
	}
}

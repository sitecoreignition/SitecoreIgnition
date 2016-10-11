using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Core.SimpleInjector;
using SimpleInjector;

namespace Ignition.Project.IgnitionDemo.Sc
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

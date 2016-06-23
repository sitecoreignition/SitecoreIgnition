using Ignition.Core.Factories;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;
using Ignition.Core.SimpleInjector;
using SimpleInjector;

namespace Ignition.Core.Installers
{
	public class CoreInstaller : SimpleInjectorInstaller
	{
		public override void Install(Container container)
		{
			container.Register<ItemContext>(Lifestyle.Scoped);
			container.Register<IAgentFactory, SimpleInjectorAgentFactory>(Lifestyle.Scoped);
			container.Register(typeof(SimpleAgent<>), new[] { ThisAssembly }, Lifestyle.Transient);
		}
	}
}

using Ignition.Core.Factories;
using Ignition.Core.Mvc;
using Ignition.Core.SimpleInjector;
using SimpleInjector;

namespace Ignition.Core.Installers
{
	public class CoreInstaller : SimpleInjectorInstaller
	{
		public override void Install(Container container)
		{
			container.Register<IAgentFactory, SimpleInjectorAgentFactory>(Lifestyle.Scoped);
            container.Register<ISitecoreServiceFactory, SitecoreServiceFactory>(Lifestyle.Scoped);
			container.Register<IViewModelDataBinder, DefaultViewModelDataBinder>(Lifestyle.Scoped);
			container.Register(typeof(SimpleAgent<>), new[] { ThisAssembly }, Lifestyle.Transient);
		}
	}
}

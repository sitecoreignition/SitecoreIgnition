using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Core.SimpleInjector;
using SimpleInjector;

namespace Ignition.Foundation.Core.Installers
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

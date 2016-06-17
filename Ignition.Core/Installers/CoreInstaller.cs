using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ignition.Core.Factories;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Core.Installers
{
	public class CoreInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<ItemContext>().LifestylePerWebRequest());
			container.Register(Component.For<IAgentFactory>().ImplementedBy<WindsorAgentFactory>().LifestylePerWebRequest());
			container.Register(Component.For(typeof(SimpleAgent<>)).LifestyleTransient());
		}
	}
}

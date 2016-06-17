using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ignition.Core.Mvc;

namespace Ignition.Root
{
	public class RootInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
			container.Register(Classes.FromThisAssembly().BasedOn(typeof(Agent<>)).LifestyleTransient());
		}
	}
}

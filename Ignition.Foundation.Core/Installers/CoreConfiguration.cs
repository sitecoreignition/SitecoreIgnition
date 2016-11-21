using System.Reflection;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Mvc;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Ignition.Foundation.Core.Installers
{
	public class CoreConfiguration : IPackage
	{
		#region IPackage
		public void RegisterServices(Container container)
		{
			var assembly = Assembly.GetExecutingAssembly();
			container.Register<IAgentFactory, SimpleInjectorAgentFactory>(Lifestyle.Scoped);
			container.Register<ISitecoreServiceFactory, SitecoreServiceFactory>(Lifestyle.Scoped);
			container.Register<IViewModelDataBinder, DefaultViewModelDataBinder>(Lifestyle.Scoped);
			container.Register<IIgnitionControllerContextFactory, IgnitionControllerContextFactory>(Lifestyle.Scoped);
			container.Register<ISitecoreSettingsFactory,SitecoreSettingsFactory>(Lifestyle.Transient);
			container.Register(typeof (SimpleAgent<>), new[] {assembly}, Lifestyle.Transient);
		}
		#endregion
	}
}
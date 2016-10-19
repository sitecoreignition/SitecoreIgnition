using System.Collections.Generic;
using System.Reflection;
using Glass.Mapper;
using Glass.Mapper.Configuration;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Mvc;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Ignition.Foundation.Core.Installers
{
	public class CoreGlassConfiguration : IGlassConfiguration, IPackage
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
		#region IGlassConfiguration
		public IEnumerable<IGlassMap> ConfigureGlass()
		{
			throw new System.NotImplementedException();
		}

		public IConfigurationLoader[] GetLoaders()
			=> new IConfigurationLoader[] {new SitecoreAttributeConfigurationLoader("Ignition.Foundation.Core")};
		#endregion
	}
}

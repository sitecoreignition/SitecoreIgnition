using System;
using System.Linq;
using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

namespace Ignition.Project.CompositionRoot
{
	public static class GlassMapperScCustom
	{
		public static IDependencyResolver CreateResolver() => new DependencyResolver(new Config());
		public static IConfigurationLoader[] GlassLoaders() => new IConfigurationLoader[] {};
		public static void PostLoad() {}
		public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
		{
			var factory = new SitecoreSettingsFactory();
			var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("Ignition"));
			var manyTypes = assemblies.SelectMany(s => s.GetTypes());
			var filteredTypes = manyTypes.Where(p => typeof (IGlassMap).IsAssignableFrom(p))
				.ToList();
			filteredTypes.ForEach(a => mapsConfigFactory.Add(() =>
				{
					var mapper= (IGlassMap) Activator.CreateInstance(a);
					var setting = mapper as IGlassSettingsConsumer;
					if (setting != null) setting.SettingsFactory = factory;
					return (IGlassMap)setting ?? mapper;
				}));
			
		}
	}
}

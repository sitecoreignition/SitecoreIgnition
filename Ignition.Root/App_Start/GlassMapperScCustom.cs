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
			AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => typeof (IGlassMap).IsAssignableFrom(p))
				.ToList()
				.ForEach(a => mapsConfigFactory.Add(() =>
				{
					var mapper= (IGlassMap) Activator.CreateInstance(a);
					var setting = mapper as IGlassSettingsConsumer;
					if (setting != null) setting.SettingsFactory = factory;
					return mapper;
				}));
		}
	}
}

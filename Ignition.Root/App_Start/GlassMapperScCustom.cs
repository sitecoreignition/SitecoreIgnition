using System;
using System.Linq;
using System.Reflection;
using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Attributes;
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
			//Load referenced assemblies
			var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
			//load possible standalone assemblies
			assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies()
					.Where(assembly => assembly.GetCustomAttributes(typeof(IgnitionAutomapAttribute)).Any())
					.Where(a => !assemblies.Contains(a))
					.Select(a => Assembly.Load(a.FullName)));
			var manyTypes = assemblies.SelectMany(s => s.GetTypes());
			var filteredTypes = manyTypes.Where(p => typeof (IGlassMap).IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)
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

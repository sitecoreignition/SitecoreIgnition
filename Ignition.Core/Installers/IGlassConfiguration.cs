using System.Collections.Generic;
using Glass.Mapper;
using Glass.Mapper.Configuration;
using Glass.Mapper.Maps;
using SimpleInjector.Packaging;

namespace Ignition.Foundation.Core.Installers
{
	public interface IGlassConfiguration
	{
		IEnumerable<IGlassMap> ConfigureGlass();
		IConfigurationLoader[] GetLoaders();

	}
}

using System.Collections.Generic;
using Glass.Mapper.Configuration;
using Glass.Mapper.Maps;

namespace Ignition.Foundation.Core.Contracts
{
	public interface IGlassConfiguration
	{
		IEnumerable<IGlassMap> ConfigureGlass();
		IConfigurationLoader[] GetLoaders();

	}
}

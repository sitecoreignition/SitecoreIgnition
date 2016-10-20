using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class NeedsChildrenMap : SitecoreGlassMap<INeedsChildren>
	{
		public override void Configure()
		{
			Map(x =>
			{
				x.AutoMap().Cachable();
				x.Children(a => a.BaseChildren).InferType();
			});
		}
	}
}
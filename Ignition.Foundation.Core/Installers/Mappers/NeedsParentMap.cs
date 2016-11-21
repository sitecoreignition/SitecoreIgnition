using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class NeedsParentMap : SitecoreGlassMap<INeedsParent>
	{
		public override void Configure()
		{
			Map(x =>
			{
				x.Cachable();
				x.Parent(a => a.Parent).InferType();
			});
		}
	}
}
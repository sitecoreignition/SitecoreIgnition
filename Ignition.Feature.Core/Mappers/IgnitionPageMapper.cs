using Glass.Mapper.Sc.Maps;
using Ignition.Feature.Core.DTOs;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Feature.Core.Mappers
{
	public class IgnitionPageMapper : SitecoreGlassMap<IIgnitionPage>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IPage>();
				x.AutoMap().Cachable();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Feature.Core.Map.Id.IgnitionPage"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
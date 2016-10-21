using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Feature.Core.Models
{
	public class IgnitionPageMapper : SitecoreGlassMap<IIgnitionPage>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IPage>();
				x.AutoMap().Cachable();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Feature.Core.Map.Id.IgnitionPage"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
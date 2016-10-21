using Glass.Mapper.Sc.Maps;
using Ignition.Feature.Content.DTOs;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.Mappers
{
	public class LinkedImageMapper : SitecoreGlassMap<ILinkedImage>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IImage>();
				ImportMap<IPrimaryLink>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Feature.Content.Map.Id.LinkedImage"));
				x.Cachable();
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
using Glass.Mapper.Sc.Maps;
using Ignition.Feature.Content.DTOs;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.Mappers
{
	public class AboutPeopleTileMapper : SitecoreGlassMap<IAboutPeopleTile>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IHeading>();
				ImportMap<IImage>();
				ImportMap<ISubtitle>();
				ImportMap<IPrimaryLink>();
				ImportMap<ISecondaryLink>();
				ImportMap<ITertiaryLink>();
				x.Cachable();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Feature.Content.Map.Id.AboutPeopleTile"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
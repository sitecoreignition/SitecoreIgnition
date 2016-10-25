using Glass.Mapper.Sc.Maps;
using Ignition.Feature.Content.DTOs;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Data.Fields;
using Ignition.Foundation.Data.Mappers;

namespace Ignition.Feature.Content.Mappers
{
	public class AboutHeroMapper : SitecoreGlassMap<IAboutHero>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IHeading>();
				ImportMap<IImage>();
				ImportMap<ICopy1>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Feature.Content.Map.Id.AboutHero"));
				x.AutoMap().Cachable();
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
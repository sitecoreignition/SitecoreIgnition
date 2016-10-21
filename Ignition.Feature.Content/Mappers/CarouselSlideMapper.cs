using Glass.Mapper.Sc.Maps;
using Ignition.Feature.Content.DTOs;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.Mappers
{
	public class CarouselSlideMapper : SitecoreGlassMap<ICarouselSlide>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IHeading>();	
				ImportMap<ICopy1>();
				ImportMap<IBackgroundImage>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Feature.Content.Map.Id.CarouselSlide"));
				x.Cachable();
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
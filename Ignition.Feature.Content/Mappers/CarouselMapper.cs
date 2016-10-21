using Glass.Mapper.Sc.Maps;
using Ignition.Feature.Content.DTOs;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Feature.Content.Mappers
{
	public class CarouselMapper : SitecoreGlassMap<ICarousel>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				ImportMap<INeedsChildren>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Feature.Content.Map.Id.Carousel"));
				x.Cachable();
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
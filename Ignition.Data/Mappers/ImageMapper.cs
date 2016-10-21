using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class ImageMapper : SitecoreGlassMap<IImage>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.Image"));
				x.Cachable();
				x.Field(a => a.Image).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Image"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
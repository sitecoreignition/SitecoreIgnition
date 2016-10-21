using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class ImageSettingMapper : SitecoreGlassMap<IImageSetting>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.ImageSetting"));
				x.Field(a => a.ImageSetting)
					.FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.ImageSetting.ImageSetting"));

			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
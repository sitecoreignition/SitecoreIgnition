using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class StringSettingMapper : SitecoreGlassMap<IStringSetting>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.StringSetting"));
				x.Field(a => a.StringSetting)
					.FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.StringSetting.StringSetting"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
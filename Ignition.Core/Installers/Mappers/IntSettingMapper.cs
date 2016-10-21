using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class IntSettingMapper : SitecoreGlassMap<IIntSetting>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.IntSetting"));
				x.Field(a => a.IntSetting)
					.FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.IntSetting.IntSetting"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
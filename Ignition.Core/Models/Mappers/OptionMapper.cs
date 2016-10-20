using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Foundation.Core.Models.Mappers
{
	public class OptionMapper : SitecoreGlassMap<IOption>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.Bucket"));
				x.Field(a => a.DataValue)
					.FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.Option.Option"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
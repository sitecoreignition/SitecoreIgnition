using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class BooleanMapper : SitecoreGlassMap<IBoolean>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.Boolean"));
				x.Cachable();
				x.Field(a => a.Checkbox).FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.Checkbox"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
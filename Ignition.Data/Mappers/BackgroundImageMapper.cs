using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class BackgroundImageMapper : SitecoreGlassMap<IBackgroundImage>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.BackgroundImage"));
				x.Cachable();
				x.Field(a => a.BackgroundImage).FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.BackgroundImage"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
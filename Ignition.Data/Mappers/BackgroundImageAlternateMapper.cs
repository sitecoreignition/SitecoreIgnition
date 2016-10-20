using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class BackgroundImageAlternateMapper : SitecoreGlassMap<IBackgroundImageAlternate>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.BackgroundImageAlternate"));
				x.Cachable();
				x.Field(a => a.BackgroundImageAlternate).FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.BackgroundImageAlternate"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
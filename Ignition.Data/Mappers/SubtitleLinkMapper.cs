using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class SubtitleLinkMapper : SitecoreGlassMap<ISubtitle>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.Cachable();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.Subtitle"));
				x.Field(a => a.Subtitle).FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.SubTitle"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
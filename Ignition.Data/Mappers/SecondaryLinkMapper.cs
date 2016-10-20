using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class SecondaryLinkMapper : SitecoreGlassMap<ISecondaryLink>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.SecondaryLink"));
				x.Cachable();
				x.Field(a => a.SecondaryLink).FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.SecondaryLink"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
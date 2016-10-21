using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class EmailLinkMapper : SitecoreGlassMap<IEmailLink>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.EmailLink"));
				x.Cachable();
				x.Field(a => a.EmailLink).FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.EmailLink"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class SingleLineTextMapper : SitecoreGlassMap<ISingleLineText>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.Cachable();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.SingleLineText"));
				x.Field(a => a.SingleLineText).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.SingleLineText"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
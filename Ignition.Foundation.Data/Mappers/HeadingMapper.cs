using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class HeadingMapper : SitecoreGlassMap<IHeading>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.Heading"));
				x.Cachable();
				x.Field(a => a.Heading).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Heading"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
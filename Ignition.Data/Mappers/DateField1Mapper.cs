using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class DateField1Mapper : SitecoreGlassMap<IDateField1>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.DateField1"));
				x.Cachable();
				x.Field(a => a.DateField1).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.DateField1"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
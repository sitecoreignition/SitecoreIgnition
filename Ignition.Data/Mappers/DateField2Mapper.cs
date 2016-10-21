using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class DateField2Mapper : SitecoreGlassMap<IDateField2>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.DateField2"));
				x.Cachable();
				x.Field(a => a.DateField2).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.DateField2"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
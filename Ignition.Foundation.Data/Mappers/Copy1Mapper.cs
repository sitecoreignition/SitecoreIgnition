using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class Copy1Mapper : SitecoreGlassMap<ICopy1>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.Copy1"));
				x.Cachable();
				x.Field(a => a.Copy1).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Copy1")).FieldType(SitecoreFieldType.RichText);
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
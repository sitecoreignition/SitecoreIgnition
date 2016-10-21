using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class Copy3Mapper : SitecoreGlassMap<ICopy3>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.Copy3"));
				x.Cachable();
				x.Field(a => a.Copy3).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Copy3")).FieldType(SitecoreFieldType.RichText);
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class TaxonomyMap : SitecoreGlassMap<ITaxonomy>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.AutoMap().Cachable();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.Taxonomy"));
				x.Field(a => a.Tags).FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.Taxonomy.Tags"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class MetadataMap : SitecoreGlassMap<IMetadata>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.AutoMap().Cachable();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.Metadata"));
				x.Field(a => a.PageTitle).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Metadata.PageTitle"));
				x.Field(a => a.PageDescription).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Metadata.PageDescription"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
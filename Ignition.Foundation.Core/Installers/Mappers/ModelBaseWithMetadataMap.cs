using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class ModelBaseWithMetadataMap : SitecoreGlassMap<IModelBaseWithMetadata>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				x.Cachable().AutoMap();
				x.Info(a => a.FullUrl).InfoType(SitecoreInfoType.Url).UrlOptions(SitecoreInfoUrlOptions.AlwaysIncludeServerUrl);
				x.Field(a => a.Created).FieldName(SettingsFactory.GetSitecoreSetting("Models.Fields.Created"));
				x.Field(a => a.Updated).FieldName(SettingsFactory.GetSitecoreSetting("Models.Fields.Updated"));
				x.Field(a => a.Sortorder).FieldName(SettingsFactory.GetSitecoreSetting("Models.Fields.Sortorder"));
				x.Info(a => a.TemplateId).InfoType(SitecoreInfoType.TemplateId);
				x.Info(a => a.TemplateName).InfoType(SitecoreInfoType.TemplateName);
			});

		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
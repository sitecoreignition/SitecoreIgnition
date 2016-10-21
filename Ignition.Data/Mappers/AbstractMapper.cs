using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class AbstractMapper : SitecoreGlassMap<IAbstract>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.Abstract"));
				x.Cachable();
				x.Field(a => a.Abstract).FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Abstract")).FieldType(SitecoreFieldType.RichText);
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Foundation.Data.Mappers
{
	public class SingleReferenceMapper : SitecoreGlassMap<ISingleReference>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.Cachable();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.SingleReference"));
				x.Field(a => a.ReferencedItem).FieldId(SettingsFactory.GetAppSetting("Models.Fields.Id.SingleReference.ReferencedItem"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
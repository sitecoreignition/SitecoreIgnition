using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.System;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class FileMapper : SitecoreGlassMap<IFile>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.File"));
				x.AutoMap();
				x.Field(a => a.MimeType).FieldName(SettingsFactory.GetAppSetting("Models.Fields.MimeType"));
				x.Field(a => a.Icon).FieldName(SettingsFactory.GetAppSetting("Models.Fields.Icon"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
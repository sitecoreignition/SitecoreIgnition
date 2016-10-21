using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.System;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class FolderMapper : SitecoreGlassMap<IFolder>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				ImportMap<INeedsChildren>();
				ImportMap<INeedsParent>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.Folder"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.System;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class MediaItemMapper : SitecoreGlassMap<IMediaItem>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				ImportMap<IFile>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.MediaItem"));
				x.AutoMap().Cachable();
				x.Info(a => a.MediaUrl).InfoType(SitecoreInfoType.MediaUrl);
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
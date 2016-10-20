using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Containers;

namespace Ignition.Foundation.Core.Models.Mappers
{
	public class OptionFolderMap : SitecoreGlassMap<IOptionFolder>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.AutoMap().Cachable();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.OptionFolder"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
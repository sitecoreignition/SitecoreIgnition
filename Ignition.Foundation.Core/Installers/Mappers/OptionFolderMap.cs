using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Containers;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class OptionFolderMap : SitecoreGlassMap<IOptionFolder>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.AutoMap().Cachable();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.OptionFolder"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
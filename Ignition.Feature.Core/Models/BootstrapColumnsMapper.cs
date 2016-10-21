using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Feature.Core.Models
{
	public class BootstrapColumnsMapper : SitecoreGlassMap<IBootstrapColumns>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IParamsBase>();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Feature.Core.Map.Id.BootstrapColumns"));
				x.AutoMap().Cachable();
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
using Glass.Mapper.Sc.Maps;
using Ignition.Feature.Core.DTOs;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Feature.Core.Mappers
{
	public class BootstrapColumnsMapper : SitecoreGlassMap<IBootstrapColumns>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IParamsBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Feature.Core.Map.Id.BootstrapColumns"));
				x.AutoMap().Cachable();
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
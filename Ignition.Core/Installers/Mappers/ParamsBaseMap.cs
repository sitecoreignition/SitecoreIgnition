using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class ParamsBaseMap : SitecoreGlassMap<IParamsBase>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.AutoMap().Cachable();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Map.Id.ParamsBase"));
			});
		}

		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
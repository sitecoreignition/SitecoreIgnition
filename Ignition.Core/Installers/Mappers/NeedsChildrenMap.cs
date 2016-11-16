using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Models.BaseModels;
namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class NeedsChildrenMap : SitecoreGlassMap<INeedsChildren>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				x.AutoMap().Cachable();
				ImportMap<IModelBase>();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.ModelBase"));
				x.Children(a => a.BaseChildren).InferType();
			});
		}

		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
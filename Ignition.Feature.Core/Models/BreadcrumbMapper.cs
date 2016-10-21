using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Installers.Mappers;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Core.Models
{
	public class BreadcrumbMapper : SitecoreGlassMap<IBreadcrumb>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IHeading>();
				x.Cachable();
				x.TemplateId(SettingsFactory.GetAppSetting("Ignition.Feature.Core.Map.Id.BreadCrumb"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
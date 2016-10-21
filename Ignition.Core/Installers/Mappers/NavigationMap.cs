using Glass.Mapper.Sc.Maps;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public class NavigationMap : SitecoreGlassMap<INavigation>, IGlassSettingsConsumer
	{
		public override void Configure()
		{
			Map(x =>
			{
				ImportMap<IModelBase>();
				x.AutoMap().Cachable();
				x.TemplateId(SettingsFactory.GetSitecoreSetting("Ignition.Map.Id.Navigation"));
				x.Field(a => a.NavigationTitle)
					.FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Navigation.NavigationTitle"));
				x.Field(a => a.HideFromNavigation)
					.FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Navigation.HideFromNavigation"));
				x.Field(a => a.HideChildrenFromNavigation)
					.FieldId(SettingsFactory.GetSitecoreSetting("Models.Fields.Id.Navigation.HideChildrenFromNavigation"));
			});
		}
		public ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
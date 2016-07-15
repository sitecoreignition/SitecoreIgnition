using Glass.Mapper.Sc;
using Ignition.Core.SimpleInjector;
using SimpleInjector;

namespace Ignition.Root
{
	public class SitecoreInstaller : SimpleInjectorInstaller
	{
		public override void Install(Container container)
		{
			container.Register<ISitecoreContext>(() => new SitecoreContext(), Lifestyle.Scoped);
		}
	}
}

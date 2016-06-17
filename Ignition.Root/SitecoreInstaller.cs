using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Controllers;

namespace Ignition.Root
{
	public class SitecoreInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<ISitecoreContext>().ImplementedBy<SitecoreContext>().LifestylePerWebRequest(),
				Component.For<ISitecoreService>().ImplementedBy<SitecoreService>().LifestylePerWebRequest()
					.DependsOn(Dependency.OnValue("databaseName", Constants.System.ProductionDatabaseName)),
				Component.For<IGlassHtml>().ImplementedBy<GlassHtml>().LifestylePerWebRequest(),
				Component.For<GlassController>(),
				Component.For<SitecoreController>());
		}
	}
}

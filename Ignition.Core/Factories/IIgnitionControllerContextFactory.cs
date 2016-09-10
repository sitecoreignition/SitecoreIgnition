using System.Web.Mvc;
using Glass.Mapper.Sc;
using Ignition.Core.Mvc;

namespace Ignition.Core.Factories
{
	public interface IIgnitionControllerContextFactory
	{
		IgnitionControllerContext GetInstance(ControllerContext controllerContext, ISitecoreContext context);
	}
}
using System.Web.Mvc;
using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Foundation.Core.Contracts
{
	public interface IIgnitionControllerContextFactory
	{
		IgnitionControllerContext GetInstance(ControllerContext controllerContext, ISitecoreContext context);
	}
}
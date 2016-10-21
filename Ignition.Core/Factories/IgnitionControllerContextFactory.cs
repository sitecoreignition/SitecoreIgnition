using System.Web.Mvc;
using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Foundation.Core.Factories
{
	public class IgnitionControllerContextFactory : IIgnitionControllerContextFactory
	{
		public IgnitionControllerContext GetInstance(ControllerContext controllerContext, ISitecoreContext context)
		{
			return new IgnitionControllerContext(controllerContext, context);
		}
	}
}

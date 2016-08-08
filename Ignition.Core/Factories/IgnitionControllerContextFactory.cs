using System.Web.Mvc;
using Glass.Mapper.Sc;
using Ignition.Core.Mvc;

namespace Ignition.Core.Factories
{
	public class IgnitionControllerContextFactory : IIgnitionControllerContextFactory
	{
		public IgnitionControllerContext GetInstance(ControllerContext controllerContext, ISitecoreContext context)
		{
			return new IgnitionControllerContext(controllerContext, context);
		}
	}
}

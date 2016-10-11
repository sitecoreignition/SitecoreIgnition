using System;

namespace Ignition.Foundation.Core.Mvc.Routing
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
	public class PublicRouteAttribute : Attribute
	{
	}
}

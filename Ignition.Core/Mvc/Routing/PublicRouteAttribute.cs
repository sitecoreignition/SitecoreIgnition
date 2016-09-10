using System;

namespace Ignition.Core.Mvc.Routing
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
	public class PublicRouteAttribute : Attribute
	{
	}
}

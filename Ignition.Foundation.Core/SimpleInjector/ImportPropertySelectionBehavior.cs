using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using SimpleInjector.Advanced;

namespace Ignition.Foundation.Core.SimpleInjector
{
	public class ImportPropertySelectionBehavior : IPropertySelectionBehavior
	{
		public bool SelectProperty(Type serviceType, PropertyInfo propertyInfo)
		{
			return propertyInfo.GetCustomAttributes<ImportAttribute>().Any();
		}
	}
}

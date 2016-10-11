using System;
using System.Linq;
using System.Reflection;
using SimpleInjector;

namespace Ignition.Foundation.Core.SimpleInjector
{
	public static class ContainerExtensions
	{
		public static void Install(this Container container, SimpleInjectorInstaller installer)
		{
			if (container == null) throw new ArgumentNullException(nameof(container));
			if (installer == null) throw new ArgumentNullException(nameof(installer));
			installer.Install(container);
		}

		public static void RegisterAllConcreteTypesFor<T>(this Container container, Assembly assembly, Lifestyle lifestyle)
		{
			RegisterAllConcreteTypesFor(container, typeof(T), assembly, lifestyle);
		}

		public static void RegisterAllConcreteTypesFor(this Container container, Type serviceType, Assembly assembly, Lifestyle lifestyle)
		{
			if (container == null) throw new ArgumentNullException(nameof(container));
			if (serviceType == null) throw new ArgumentNullException(nameof(serviceType));
			if (assembly == null) throw new ArgumentNullException(nameof(assembly));
			if (lifestyle == null) throw new ArgumentNullException(nameof(lifestyle));

			var types = assembly.GetExportedTypes()
			  .Where(type => serviceType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
			foreach (var type in types)
			{
				var registration = lifestyle.CreateRegistration(type, container);
				container.AddRegistration(type, registration);
			}
		}
	}
}

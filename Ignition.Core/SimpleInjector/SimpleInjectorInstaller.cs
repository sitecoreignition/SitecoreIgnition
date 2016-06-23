using System.Reflection;
using SimpleInjector;

namespace Ignition.Core.SimpleInjector
{
	public abstract class SimpleInjectorInstaller
	{
		protected Assembly ThisAssembly => GetType().Assembly;
		public abstract void Install(Container container);
	}
}

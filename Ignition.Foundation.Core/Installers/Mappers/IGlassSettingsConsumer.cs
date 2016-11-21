using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;

namespace Ignition.Foundation.Core.Installers.Mappers
{
	public interface IGlassSettingsConsumer
	{
		ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
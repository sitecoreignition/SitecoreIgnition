using Ignition.Foundation.Core.Factories;

namespace Ignition.Foundation.Core.Models.Mappers
{
	public interface IGlassSettingsConsumer
	{
		ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
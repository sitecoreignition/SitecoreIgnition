namespace Ignition.Foundation.Core.Contracts
{
	public interface ISitecoreSettingsFactory
	{
		string GetAppSetting(string key);
		string GetAppSetting(string key, string arg);
	}
}

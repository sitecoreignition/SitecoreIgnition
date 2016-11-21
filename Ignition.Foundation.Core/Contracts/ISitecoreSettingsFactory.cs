namespace Ignition.Foundation.Core.Contracts
{
	public interface ISitecoreSettingsFactory
	{
		string GetSitecoreSetting(string key);
		string GetSitecoreSetting(string key, string arg);
	}
}

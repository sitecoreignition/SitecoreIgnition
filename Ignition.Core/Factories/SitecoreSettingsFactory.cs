using Ignition.Foundation.Core.Contracts;

namespace Ignition.Foundation.Core.Factories
{
	public class SitecoreSettingsFactory : ISitecoreSettingsFactory
	{
		public string GetSitecoreSetting(string key)
		{
			return Sitecore.Configuration.Settings.GetSetting(key);
		}

		public string GetSitecoreSetting(string key, string arg)
		{
			return Sitecore.Configuration.Settings.GetSetting(key, arg);
		}
	}
}

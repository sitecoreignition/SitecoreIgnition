using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.Foundation.Core.Factories
{
	public interface ISitecoreSettingsFactory
	{
		string GetAppSetting(string key);
		string GetAppSetting(string key, string arg);
	}
}

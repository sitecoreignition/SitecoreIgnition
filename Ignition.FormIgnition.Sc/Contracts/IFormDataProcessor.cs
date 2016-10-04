using System.Collections.Generic;

namespace Ignition.FormIgnition.Sc.Contracts
{
	public interface IFormDataProcessor
	{
		Dictionary<string,string> ProcessHtml(Dictionary<string, string> html);
	}
}

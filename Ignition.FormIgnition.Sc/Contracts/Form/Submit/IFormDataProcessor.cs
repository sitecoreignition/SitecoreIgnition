using System.Collections.Generic;

namespace Ignition.FormIgnition.Sc.Contracts.Form.Submit
{
	public interface IFormDataProcessor
	{
		Dictionary<string,string> ProcessSubmission(Dictionary<string, string> submission);
	}
}

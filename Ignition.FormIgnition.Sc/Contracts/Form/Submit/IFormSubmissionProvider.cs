using System.Collections.Generic;

namespace Ignition.FormIgnition.Sc.Contracts.Form.Submit
{
	public interface IFormSubmissionProvider
	{
		bool PostData(Dictionary<string, string> data);
	}
}

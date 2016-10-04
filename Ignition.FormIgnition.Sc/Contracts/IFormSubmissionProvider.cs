using System.Collections.Generic;

namespace Ignition.FormIgnition.Sc.Contracts
{
	public interface IFormSubmissionProvider
	{
		bool PostData(Dictionary<string, string> data);
	}
}

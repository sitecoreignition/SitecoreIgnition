using System.Collections.Generic;
using System.Web.Mvc;

namespace Ignition.FormIgnition.Sc.Contracts.Form.Submit
{
	public interface IFormFailedSubmitProcessor
	{
		ActionResult ProcessFailed(Dictionary<string, string> postedData);
	}
}

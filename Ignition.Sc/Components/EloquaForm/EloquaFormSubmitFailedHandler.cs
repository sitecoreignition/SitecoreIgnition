using System.Collections.Generic;
using System.Web.Mvc;
using Ignition.FormIgnition.Sc.Contracts.Form.Submit;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormSubmitFailedHandler : IFormFailedSubmitProcessor
	{
		public ActionResult ProcessFailed(Dictionary<string, string> postedData)
		{
			throw new System.NotImplementedException();
		}
	}
}
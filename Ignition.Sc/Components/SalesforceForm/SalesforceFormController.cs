using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.SalesforceForm
{
	public class SalesforceFormController : IgnitionController
	{
		public ActionResult SalesforceForm()
		{
			return View<SalesforceFormViewModel>();
		}

		[HttpPost]
		public ActionResult SalesforceFormPost()
		{
			return null;
		}
	}
}
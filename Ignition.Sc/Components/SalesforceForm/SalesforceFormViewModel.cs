using Ignition.Core.Mvc;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.SalesforceForm
{
	public class SalesforceFormViewModel : BaseViewModel
	{
		public ICopy1 FormContent { get; set; }
		public IHeading Title { get; set; }
	}
}
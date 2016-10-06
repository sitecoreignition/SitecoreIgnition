using System.ComponentModel.Composition;
using System.Web.Mvc;
using Glass.Mapper;
using Ignition.Core.Models.Settings;
using Ignition.FormIgnition.Sc.Mvc;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormController : IgnitionFormController
	{
		[Import]
		public EloquaFormDataProvider FormDataProvider { get; set; }
		[Import]
		public EloquaFormProcessor FormProcessor { get; set; }
		[Import]
		public EloquaFormSubmitProcessor FormSubmitProcessor { get; set; }
		[Import]
		public EloquaFormSubmissionProvider FormSubmissionProvider { get; set; }
		[Import]
		public EloquaFormSubmitFailedHandler FormSubmitFailed { get; set; }
		public ActionResult DisplayForm()
		{
			return Form<EloquaFormDataProvider, EloquaFormProcessor, EloquaFormAgent, 
				EloquaFormViewModel>(new EloquaFormDataProvider(), new EloquaFormProcessor(), DataSourceItem.CastTo<IOption>()?.DataValue);
		}
		[HttpPost]
		public ActionResult PostForm()
		{
			return Submit(FormSubmitProcessor, FormSubmissionProvider, FormSubmitFailed);
		}
	}
}
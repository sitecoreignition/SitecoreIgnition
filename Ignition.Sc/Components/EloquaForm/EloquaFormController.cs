using System.ComponentModel.Composition;
using System.Web.Mvc;
using Glass.Mapper;
using Ignition.Core.Models.Settings;
using Ignition.FormIgnition.Sc.Contracts;
using Ignition.FormIgnition.Sc.Contracts.Form;
using Ignition.FormIgnition.Sc.Mvc;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormController : IgnitionFormController
	{
		protected sealed override IFormConfiguration Configuration { get; set; }
		protected sealed override IFormAuthentication FormAuthentication { get; set; }

		[Import]
		public EloquaFormRequestDataProvider FormRequestDataProvider { get; set; }
		[Import]
		public EloquaFormRequestProcessor FormRequestProcessor { get; set; }
		[Import]
		public EloquaFormSubmissionSubmitProcessor FormSubmissionSubmitProcessor { get; set; }
		[Import]
		public EloquaFormSubmissionProvider FormSubmissionProvider { get; set; }
		[Import]
		public EloquaFormSubmitFailedHandler FormSubmitFailed { get; set; }

		public EloquaFormController(EloquaFormAuthentication authentication)     
		{
			FormAuthentication = authentication;
		}

		public ActionResult DisplayForm()
		{
			return Form<EloquaFormRequestDataProvider, EloquaFormRequestProcessor, EloquaFormAgent, EloquaFormViewModel>(
				FormAuthentication, new EloquaFormRequestDataProvider(FormAuthentication,Configuration as EloquaFormAuthentication), new EloquaFormRequestProcessor(), DataSourceItem.CastTo<IOption>()?.DataValue);
		}

		[HttpPost]
		public ActionResult PostForm()
		{
			return Submit(FormSubmissionSubmitProcessor, FormSubmissionProvider, FormSubmitFailed);
		}
	}
}
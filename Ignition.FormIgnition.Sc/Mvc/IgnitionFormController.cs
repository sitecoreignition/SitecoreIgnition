using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.FormIgnition.Sc.Contracts;
using Ignition.FormIgnition.Sc.Contracts.Form;
using Ignition.FormIgnition.Sc.Contracts.Form.Request;
using Ignition.FormIgnition.Sc.Contracts.Form.Submit;

namespace Ignition.FormIgnition.Sc.Mvc
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class IgnitionFormController : IgnitionController
	{
		protected abstract IFormConfiguration Configuration { get; set; }
		protected abstract IFormAuthentication FormAuthentication { get; set; }
		#region Form Overloads

		/// <summary>
		/// Takes an API provider and a form html processor and then returns View&lt;TAgent,TViewModel&gt;(), passing in the resulting html string.
		/// </summary>
		/// <typeparam name="TFormDataProvider"></typeparam>
		/// <typeparam name="TFormProcessor"></typeparam>
		/// <typeparam name="TAgent"></typeparam>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="formAuthProvider"></param>
		/// <param name="processor"></param>
		/// <param name="formId"></param>
		/// <returns></returns>
		public ViewResult Form<TFormDataProvider, TFormProcessor, TAgent, TViewModel>(IFormAuthentication formAuthProvider, TFormDataProvider dataProvider, TFormProcessor processor, string formId)
			where TFormDataProvider : IFormDataProvider
			where TFormProcessor : IFormHtmlProcessor
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
		{
			if (formAuthProvider == null) throw new ArgumentNullException(nameof(formAuthProvider));
			if (processor == null) throw new ArgumentNullException(nameof(processor));

			return View<TAgent, TViewModel>(processor.GetHtmlFormRaw(dataProvider.GetForm(formId), ControllerContext.HttpContext));
		}

		#endregion
		#region Submit
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TFormDataProcessor"></typeparam>
		/// <typeparam name="TFormSubmissionProcessor"></typeparam>
		/// <typeparam name="TFailedSubmitProcessor"></typeparam>
		/// <param name="processor"></param>
		/// <param name="submittor"></param>
		/// <param name="failed"></param>
		/// <returns></returns>
		public ActionResult Submit<TFormDataProcessor, TFormSubmissionProcessor, TFailedSubmitProcessor>(
			TFormDataProcessor processor, 
			TFormSubmissionProcessor submittor, 
			TFailedSubmitProcessor failed
			)
			where TFormDataProcessor : IFormDataProcessor
			where TFormSubmissionProcessor : IFormSubmissionProvider
			where TFailedSubmitProcessor : IFormFailedSubmitProcessor
		{
			var form = Request.Form.Cast<string>()
					.Select(s => new { Key = s, Value = Request.Form[s] })
					.ToDictionary(p => p.Key, p => p.Value);
			return submittor.PostData(processor.ProcessSubmission(form)) ? Redirect(Configuration.SuccessRedirect) : failed.ProcessFailed(form);
		}
		#endregion
	}
}
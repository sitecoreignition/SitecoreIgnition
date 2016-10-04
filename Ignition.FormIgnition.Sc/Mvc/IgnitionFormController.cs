using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.FormIgnition.Sc.Contracts;

namespace Ignition.FormIgnition.Sc.Mvc
{
	/// <summary>
	/// 
	/// </summary>
	public class IgnitionFormController : IgnitionController
	{
		protected IFormConfiguration Configuration { get; set; }
		protected IAuthentication Authentication { get; set; }
		#region Form Overloads

		/// <summary>
		/// Takes an API provider and a form html processor and then returns View&lt;TAgent,TViewModel&gt;(), passing in the resulting html string.
		/// </summary>
		/// <typeparam name="TFormProvider"></typeparam>
		/// <typeparam name="TFormProcessor"></typeparam>
		/// <typeparam name="TAgent"></typeparam>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="formProvider"></param>
		/// <param name="processor"></param>
		/// <param name="formId"></param>
		/// <returns></returns>
		public ViewResult Form<TFormProvider, TFormProcessor, TAgent, TViewModel>(TFormProvider formProvider, TFormProcessor processor, string formId)
			where TFormProvider : IFormDataProvider
			where TFormProcessor : IFormHtmlProcessor
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
		{
			if (formProvider == null) throw new ArgumentNullException(nameof(formProvider));
			if (processor == null) throw new ArgumentNullException(nameof(processor));

			return View<TAgent, TViewModel>(processor.GetHtmlFormRaw(formProvider.GetForm(Authentication, formId)));
		}
		///// <summary>
		///// 
		///// </summary>
		///// <typeparam name="TFormProvider"></typeparam>
		///// <typeparam name="TFormProcessor"></typeparam>
		///// <typeparam name="TAgent"></typeparam>
		///// <typeparam name="TViewModel"></typeparam>
		///// <param name="formProvider"></param>
		///// <param name="processor"></param>
		///// <param name="args"></param>
		///// <returns></returns>
		//public ViewResult Form<TFormProvider, TFormProcessor, TAgent, TViewModel>(TFormProvider formProvider, TFormProcessor processor, string[] args)
		//	where TFormProvider : IFormDataProvider
		//	where TFormProcessor : IFormHtmlProcessor
		//	where TAgent : Agent<TViewModel>
		//	where TViewModel : BaseViewModel, new()
		//{
		//	if (formProvider == null) throw new ArgumentNullException(nameof(formProvider));
		//	if (processor == null) throw new ArgumentNullException(nameof(processor));

		//	return View<TAgent, TViewModel>(processor.GetHtmlFormRaw(formProvider.GetHtmlFormRaw(args)));
		//}
		#endregion
		#region Process
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
			where TFailedSubmitProcessor : IFailedSubmitProcessor
		{
			var form = Request.Form.Cast<string>()
					.Select(s => new { Key = s, Value = Request.Form[s] })
					.ToDictionary(p => p.Key, p => p.Value);
			return submittor.PostData(processor.ProcessHtml(form)) ? Redirect(Configuration.SuccessRedirect) : failed.ProcessFailed(form);
		}
		#endregion
	}
}
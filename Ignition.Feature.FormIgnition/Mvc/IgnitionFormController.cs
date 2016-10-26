using System.Linq;
using System.Web.Mvc;
using Ignition.FormIgnition.Sc.Contracts.Form;
using Ignition.Foundation.Core.Mvc;

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
		/// 
		/// </summary>
		/// <typeparam name="TFormEndpoint"></typeparam>
		/// <typeparam name="TFormGetProcessor"></typeparam>
		/// <typeparam name="TAgent"></typeparam>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="endPoint"></param>
		/// <param name="processor"></param>
		/// <returns></returns>
		public ViewResult Form<TFormEndpoint, TFormGetProcessor, TAgent, TViewModel>(
			TFormEndpoint endPoint, 
			TFormGetProcessor processor)
			where TFormEndpoint : IFormEndpoint
			where TFormGetProcessor : IFormGetProcessor
			where TAgent : Agent<TViewModel>
			where TViewModel : IgnitionViewModel, new()
		{
			return View<TAgent, TViewModel>(processor);
		}
		#endregion
		#region Submit
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TFormEndPoint"></typeparam>
		/// <typeparam name="TFormGetProcessor"></typeparam>
		/// <typeparam name="TFormPostProcessor"></typeparam>
		/// <param name="endpoint"></param>
		/// <param name="getProcessor"></param>
		/// <param name="postProcessor"></param>
		/// <returns></returns>
		public ActionResult Submit<TFormEndPoint, TFormGetProcessor, TFormPostProcessor>(
			TFormEndPoint endpoint, 
			TFormGetProcessor getProcessor, 
			TFormPostProcessor postProcessor)
			where TFormEndPoint : IFormEndpoint
			where TFormGetProcessor : IFormGetProcessor
			where TFormPostProcessor : IFormPostProcessor
		{
			return postProcessor.PostForm(getProcessor, Request.Form.Cast<string>()
				.Select(s => new { Key = s, Value = Request.Form[s] }).ToDictionary(p => p.Key, p => p.Value));
		}
		#endregion
	}
}
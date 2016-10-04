using System;
using Ignition.FormIgnition.Sc.Contracts;

namespace Ignition.FormIgnition.Sc.Orchestration
{
	public class FormSubmitOrchestrator
	{
		public string Form<TFormProvider, TFormProcessor>(TFormProvider formProvider, TFormProcessor processor, string[] args) 
			where TFormProvider : IFormDataProvider
			where TFormProcessor :IFormDataProcessor
		{
			if (formProvider == null) throw new ArgumentNullException(nameof(formProvider));
			if (processor == null) throw new ArgumentNullException(nameof(processor));

			return processor.ProcessHtml(formProvider.GetHtmlFormRaw(args));
		}
	}
}
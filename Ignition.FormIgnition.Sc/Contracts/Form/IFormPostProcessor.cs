using System.Collections.Generic;
using System.Web.Mvc;

namespace Ignition.FormIgnition.Sc.Contracts.Form
{
	public interface IFormPostProcessor
	{
		ActionResult PostForm<TFormGetProcessor>(TFormGetProcessor getProcessor, Dictionary<string, string> form) where TFormGetProcessor : IFormGetProcessor;
	}
}

using HtmlAgilityPack;

namespace Ignition.FormIgnition.Sc.Contracts.Form.Request
{
	public interface IFormDataProvider
	{
		HtmlDocument GetForm(string formId);
	}
}

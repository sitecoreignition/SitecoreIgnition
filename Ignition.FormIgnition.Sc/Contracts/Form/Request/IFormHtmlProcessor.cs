using System.Web;
using HtmlAgilityPack;

namespace Ignition.FormIgnition.Sc.Contracts.Form.Request
{
	public interface IFormHtmlProcessor
	{
		string GetHtmlFormRaw(HtmlDocument data, HttpContextBase context);
	}
}

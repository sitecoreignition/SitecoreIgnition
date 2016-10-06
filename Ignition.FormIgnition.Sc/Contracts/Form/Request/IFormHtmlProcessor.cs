using System.Web;

namespace Ignition.FormIgnition.Sc.Contracts.Form.Request
{
	public interface IFormHtmlProcessor
	{
		string GetHtmlFormRaw(string data, HttpContext context);
	}
}

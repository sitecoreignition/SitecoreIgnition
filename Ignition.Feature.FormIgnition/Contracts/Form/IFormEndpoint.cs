using HtmlAgilityPack;

namespace Ignition.FormIgnition.Sc.Contracts.Form
{
	public interface IFormEndpoint
	{
		#region Authentication
		IFormConfiguration Configuration { get; }
		void Authenticate();
		bool IsAuthenticated();
		#endregion
		#region Connector
		HtmlDocument GetFormByIdentifier(string identifier);
		string[] GetFormIdentifiers();
		TContact GetContact<TContact>(string email);
		dynamic GetContact(string email);
		#endregion
	}
}

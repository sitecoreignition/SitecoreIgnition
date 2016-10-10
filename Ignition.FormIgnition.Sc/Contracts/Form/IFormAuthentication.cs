namespace Ignition.FormIgnition.Sc.Contracts.Form
{
	public interface IFormAuthentication
	{
		string UserName { get; set; }
		string Password { get; }
		void SetPassword(string value);
		string BusinessUnit { get; set; }
		void UpdateFromCookie();
		string BaseApiUrl { get; set; }
		string GetForm(IFormAuthentication formAuthentication, string formId);
		string GetBase64AuthString { get; }
	}
}

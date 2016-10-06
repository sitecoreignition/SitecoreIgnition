namespace Ignition.FormIgnition.Sc.Contracts.Form.Request
{
	public interface IFormDataProvider
	{
		string GetForm(IFormAuthentication auth, string formId);
	}
}

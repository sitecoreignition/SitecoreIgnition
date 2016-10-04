namespace Ignition.FormIgnition.Sc.Contracts
{
	public interface IFormDataProvider
	{
		string GetForm(IAuthentication auth, string formId);
	}
}

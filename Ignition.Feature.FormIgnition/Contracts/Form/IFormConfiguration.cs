namespace Ignition.FormIgnition.Sc.Contracts.Form
{
	public interface IFormConfiguration : IFormAuthentication
	{
		string SuccessRedirect { get; set; }
		IFormAuthentication Authentication { get; set; }
	}
}

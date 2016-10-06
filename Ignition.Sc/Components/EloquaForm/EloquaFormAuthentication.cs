using System;
using System.Text;
using Ignition.FormIgnition.Sc.Contracts;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormAuthentication : IFormAuthentication
	{
		public string UserName { get; set; } = "jon.upchurch";
		public string Password { get; private set; } = "Perficient1";
		public void SetPassword(string value)
		{
			if (!string.IsNullOrEmpty(value)) Password = value;
			else throw new InvalidOperationException("Password Cannot be empty!");
		}

		public string BusinessUnit { get; set; } = "perficientpartner";
		public void UpdateFromCookie()
		{
			throw new NotImplementedException();
		}

		public string BaseApiUrl { get; set; } = "https://secure.p03.eloqua.com/API/REST/1.0/";

		public string GetAuthString()
		{
			return $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{BusinessUnit}\\{UserName}:{Password}"))}";
		}
	}
}
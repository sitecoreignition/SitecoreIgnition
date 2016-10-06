using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ignition.FormIgnition.Sc.Contracts;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormAuthentication : IFormAuthentication
	{
		public string UserName { get; set; }
		public string Password { get; private set; }
		public void SetPassword(string value)
		{
			if (!string.IsNullOrEmpty(value)) Password = value;
			else throw new InvalidOperationException("Password Cannot be empty!");
		}

		public string BusinessUnit { get; set; }
		public void UpdateFromCookie()
		{
			throw new NotImplementedException();
		}

		public string GetAuthString()
		{
			//return $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes("perficientpartner\\jon.upchurch:Perficient1"))}";
			return $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{BusinessUnit}\\{UserName}:{Password}"))}";
		}
	}
}
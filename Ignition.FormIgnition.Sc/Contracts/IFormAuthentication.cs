using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.FormIgnition.Sc.Contracts
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
	}
}

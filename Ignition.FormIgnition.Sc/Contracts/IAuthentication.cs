using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.FormIgnition.Sc.Contracts
{
	public interface IAuthentication
	{
		string UserName { get; set; }
		string Password { get; }
		void SetPassword();
		string BusinessUnit { get; set; }
		void UpdateFromCookie();
	}
}

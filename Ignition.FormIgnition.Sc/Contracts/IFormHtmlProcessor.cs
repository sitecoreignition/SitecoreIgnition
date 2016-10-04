using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.FormIgnition.Sc.Contracts
{
	public interface IFormHtmlProcessor
	{
		string GetHtmlFormRaw(string data);
	}
}

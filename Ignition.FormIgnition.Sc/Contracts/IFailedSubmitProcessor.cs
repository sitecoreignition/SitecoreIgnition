using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ignition.FormIgnition.Sc.Contracts
{
	public interface IFailedSubmitProcessor
	{
		ActionResult ProcessFailed(Dictionary<string, string> postedData);
	}
}

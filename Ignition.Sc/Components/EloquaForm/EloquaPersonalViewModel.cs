using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaPersonalViewModel : BaseViewModel
	{
		public string Message => $"<h2>Welcome Visitor {"From " + State}!</h2>";

		public string State { get; set; } = "The Internet";
	}
}
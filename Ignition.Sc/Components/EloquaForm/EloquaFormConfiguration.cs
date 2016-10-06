using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignition.FormIgnition.Sc.Contracts.Form;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormConfiguration : IFormConfiguration
	{
		public string SuccessRedirect { get; set; }
		public string FormUrl { get; set; } = "assets/form/";
	}
}
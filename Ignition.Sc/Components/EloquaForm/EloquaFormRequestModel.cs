using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormRequestModel
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string emailAddress { get; set; }
		public string company { get; set; }
		public string address1 { get; set; }
		public string city { get; set; }
		public string stateProv { get; set; }
		public string zipPostal { get; set; }
	}
}
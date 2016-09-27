using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLL.SP2013.Internet.Eloqua.Models.Form;
using System.Runtime.Serialization;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaRestFormPost
	{
		[DataMember(Name = "id")]
		public string Id { get; set; } = "33";
		[DataMember(Name = "fieldValues")]
		public object FieldValues { get; set; } 
	}
}
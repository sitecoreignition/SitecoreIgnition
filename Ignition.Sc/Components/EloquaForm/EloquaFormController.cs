using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Ignition.Core.Mvc;
using JLL.SP2013.Internet.Eloqua.Client;
using JLL.SP2013.Internet.Eloqua.Models.Form;
using JLL.SP2013.Internet.Eloqua.Transform;
using Newtonsoft.Json;
using Sitecore.ContentSearch.Linq.Nodes;
using Sitecore.Diagnostics;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormController : IgnitionController
	{
		public ViewResult EloquaForm() => View<EloquaFormAgent, EloquaFormViewModel>();

		[HttpPost]
		public ActionResult EloquaFormPost(EloquaFormRequestModel data)
		{
			var request = (HttpWebRequest)WebRequest.Create("https://secure.p03.eloqua.com/API/REST/1.0/assets/form/33");
			request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes("perficientpartner\\jon.upchurch:gd151Waite"))}");
			var result = new StreamReader(request.GetResponse().GetResponseStream() ?? new MemoryStream()).ReadToEnd();
			dynamic formInfo = System.Web.Helpers.Json.Decode(result);
			var fieldMaps = new Dictionary<string, string>();
			foreach (var item in formInfo.Elements)
			{
				fieldMaps.Add(item.htmlName,item.id);
			}

			var client = new EloquaRestServiceClient("perficientpartner", "jon.upchurch", "gd151Waite");

			var transformer  = new EloquaToJllHtmlTransformer(client, "1162309230", "formSubmit");
			var html = transformer.GenerateForm(33);
			var dict = data.GetType().GetProperties().ToDictionary(prop => prop.Name, prop => (string)prop.GetValue(data));
			var values = dict.Select(item => item.Key).Select(i => new { Key = i, Value = dict[i] });
			
			var formdata = new FormData
			{
				Id = "33",
				FieldValues = dict.Select(a => new FieldValueRest10 {Id = fieldMaps[a.Key], Value = a.Value}).ToList()
			};
			var resultSet = client.PostFormData(33, formdata);
			return null;
		}
	}
}              

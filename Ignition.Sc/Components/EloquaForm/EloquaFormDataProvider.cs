using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using Ignition.FormIgnition.Sc.Contracts;
using Ignition.FormIgnition.Sc.Contracts.Form.Request;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormDataProvider : IFormDataProvider
	{
		public string GetForm(IFormAuthentication auth, string formId)
		{
			var request = (HttpWebRequest)WebRequest.Create("https://secure.p03.eloqua.com/API/REST/1.0/assets/form/33");
			request.Headers.Add("Authorization", auth.GetAuthString());
			var result = new StreamReader(request.GetResponse().GetResponseStream() ?? new MemoryStream()).ReadToEnd();
			dynamic formInfo = System.Web.Helpers.Json.Decode(result);
			var doc = new HtmlDocument();
			doc.LoadHtml(formInfo.Html);
		}
	}
}
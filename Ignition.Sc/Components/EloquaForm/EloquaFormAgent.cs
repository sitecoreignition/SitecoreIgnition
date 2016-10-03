using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using Ignition.Core.Mvc;


namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormAgent : Agent<EloquaFormViewModel>
	{
		public override void PopulateModel()
		{
			var request = (HttpWebRequest)WebRequest.Create("https://secure.p03.eloqua.com/API/REST/1.0/assets/form/33");
			request.Headers.Add("Authorization", EloquaAuthProvider.GetAuthString());
			var result = new StreamReader(request.GetResponse().GetResponseStream() ?? new MemoryStream()).ReadToEnd();
			dynamic formInfo = System.Web.Helpers.Json.Decode(result);
			var doc = new HtmlDocument();
			doc.LoadHtml(formInfo.Html);
			var form = doc.DocumentNode.FirstChild.FirstChild;
			form.SetAttributeValue("action", AgentContext.HttpContext.Request.Url?.PathAndQuery);
			var scController = doc.CreateElement("input");
			scController.Attributes.AddManyAttributes(new Dictionary<string, string> { { "type","hidden"}, {"name", "scController"}, {"value", "EloquaForm"}});
			form.InsertAfter(scController, form.FirstChild);
			var scAction = doc.CreateElement("input");
			scAction.Attributes.AddManyAttributes(new Dictionary<string, string> { { "type", "hidden" }, { "name", "scAction" }, { "value", "EloquaFormPost" } });
			form.InsertAfter(scAction, form.FirstChild);
			ViewModel.Html = doc.DocumentNode.OuterHtml;
		}
	}

	public static class AttributeExtensions
	{
		public static void AddManyAttributes(this HtmlAttributeCollection attributeCollection, Dictionary<string, string> values)
		{
			foreach (var key in values.Keys)
			{
				attributeCollection.Add(key, values[key]);
			}
		}
	}
}
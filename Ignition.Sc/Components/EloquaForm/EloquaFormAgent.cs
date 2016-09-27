using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.HtmlControls;
using HtmlAgilityPack;
using Ignition.Core.Mvc;
using JLL.SP2013.Internet.Eloqua.Client;
using JLL.SP2013.Internet.Eloqua.Transform;
using Newtonsoft.Json;


namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormAgent : Agent<EloquaFormViewModel>
	{
		public override void PopulateModel()
		{
			var request = (HttpWebRequest)WebRequest.Create("https://secure.p03.eloqua.com/API/REST/1.0/assets/form/33");
			request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes("perficientpartner\\jon.upchurch:gd151Waite"))}");
			var result = new StreamReader(request.GetResponse().GetResponseStream() ?? new MemoryStream()).ReadToEnd();
			dynamic formInfo = System.Web.Helpers.Json.Decode(result);
			var actionFix = new Regex(@"action="".*?""");
			var scValues = new Regex(@"name=""elqSiteId"">");
			var cleaned = actionFix.Replace(formInfo.Html,
				$"action=\"{AgentContext.HttpContext.Request.Url?.PathAndQuery}\"");
			var doc = new HtmlDocument();
			doc.LoadHtml(cleaned);
			var input = doc.DocumentNode.FirstChild.FirstChild;
			//input.InsertAfter()
			var scController = doc.CreateElement("input");
			scController.Attributes.Add("type", "hidden");
			scController.Attributes.Add("name", "scController");
			scController.Attributes.Add("value", "EloquaForm");
			input.InsertAfter(scController, input.FirstChild);
			var scAction = doc.CreateElement("input");
			scAction.Attributes.Add("type", "hidden");
			scAction.Attributes.Add("name", "scAction");
			scAction.Attributes.Add("value", "EloquaFormPost");
			input.InsertAfter(scAction, input.FirstChild);
			cleaned = scValues.Replace(cleaned,
				@"name=\""elqSiteId\""><input value=""EloquaForm"" type=""hidden"" name=""scController""><input value=""EloquaForm"" type=""hidden"" name=""scAction"">");
			ViewModel.Html = doc.DocumentNode.OuterHtml;
		}
	}
}
 
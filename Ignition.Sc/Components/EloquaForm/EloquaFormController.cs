using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using Ignition.Core.Mvc;
using JLL.SP2013.Internet.Eloqua.Client;
using JLL.SP2013.Internet.Eloqua.Models.Form;
using Sitecore.Mvc.Extensions;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormController : IgnitionController
	{
		public ViewResult EloquaForm() => View<EloquaFormAgent, EloquaFormViewModel>();

		[HttpPost]
		public ActionResult EloquaFormPost()
		{
			var request = (HttpWebRequest)WebRequest.Create("https://secure.p03.eloqua.com/API/REST/1.0/assets/form/33");
			request.Headers.Add("Authorization", EloquaAuthHelper.GetAuthString());
			var result = new StreamReader(request.GetResponse().GetResponseStream() ?? new MemoryStream()).ReadToEnd();

			dynamic formInfo = System.Web.Helpers.Json.Decode(result);

			var fieldMaps = new Dictionary<string, string>();
			foreach (var item in formInfo.Elements) { fieldMaps.Add(item.htmlName ?? "error", item.id); }

			var client = EloquaAuthHelper.GetEloquaClient();
			var dict = CastToDictionary(Request.Form);
			var formdata = new FormData
			{
				Id = "33",
				FieldValues = dict.Where(a=>fieldMaps.ContainsKey(a.Key)).Select(a => new FieldValueRest10 { Id = fieldMaps[a.Key], Value = a.Value }).ToList()
			};
			var resultSet = client.PostFormData(33, formdata);
			var email = formdata.FieldValues.Where(a => a.Id == fieldMaps["emailAddress"]).Select(a=>a.Value).FirstOrDefault();
			if (resultSet.Id.IsWhiteSpaceOrNull() || email.IsNullOrEmpty()) return View<EloquaFormAgent, EloquaFormViewModel>(dict);
			if (Request.Cookies["email"] !=null)
			{
				Request.Cookies["email"].Value = email;
			}
			else
			{
				Response.Cookies.Add(new HttpCookie("email", email) {Expires = DateTime.Now.AddDays(1)});
			}
			return Redirect($"{HttpContext.Request.Url?.PathAndQuery}/ThankYou");
		}

		public ViewResult EloquaPersonalize()
		{
			return View<EloquaPersonalAgent, EloquaPersonalViewModel>(Request.Cookies["email"]?.Value);
		}

		public Dictionary<string,string> CastToDictionary(NameValueCollection source)
		{
			return source.Cast<string>().Select(s => new {Key = s, Value = source[s]}).ToDictionary(p => p.Key, p => p.Value);
		}
	}
}

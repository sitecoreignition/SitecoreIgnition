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
		private readonly EloquaFormAuthentication _authentication;
		private readonly EloquaFormConfiguration _configuration;

		public EloquaFormDataProvider(EloquaFormAuthentication authentication, EloquaFormConfiguration configuration)
		{
			if (authentication == null) throw new ArgumentNullException(nameof(authentication));
			if (configuration == null) throw new ArgumentNullException(nameof(configuration));
			_authentication = authentication;
			_configuration = configuration;
		}

		public HtmlDocument GetForm(string formId)
		{
			
			var request = (HttpWebRequest)WebRequest.Create($"{_authentication.BaseApiUrl}{_configuration.FormUrl}");
			request.Headers.Add("Authorization", _authentication.GetAuthString());
			var result = new StreamReader(request.GetResponse().GetResponseStream() ?? new MemoryStream()).ReadToEnd();
			dynamic formInfo = System.Web.Helpers.Json.Decode(result);
			var doc = new HtmlDocument();
			doc.LoadHtml(formInfo.Html);
			return doc;
		}
	}
}
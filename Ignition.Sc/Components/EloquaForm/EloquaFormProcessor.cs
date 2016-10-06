using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using Ignition.Core.Mvc;
using Ignition.FormIgnition.Sc.Contracts.Form.Request;
using HtmlDocument = Sitecore.WordOCX.HtmlDocument.HtmlDocument;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaFormProcessor : IFormHtmlProcessor
	{
		public string GetHtmlFormRaw(HtmlAgilityPack.HtmlDocument data, HttpContextBase context)
		{
			throw new NotImplementedException();
		}
		public void AddSitecoreFormFields(ref HtmlDocument doc, string controllerName, string actionname, HttpContext context)
		{
			if (doc == null)
			{
				throw new NullReferenceException("Document Cannot be null");
			}

			var form = doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(a => a.Name.ToLower() == "form");
			if (form == null) throw new NullReferenceException("Unable to process the form out of the html document.");
			form.SetAttributeValue("action", context.Request.Url?.PathAndQuery);
			var scController = doc.CreateElement("input");
			scController.Attributes.AddManyAttributes(new Dictionary<string, string> { { "type", "hidden" }, { "name", "scController" }, { "value", "EloquaForm" } });
			form.InsertAfter(scController, form.FirstChild);
			var scAction = doc.CreateElement("input");
			scAction.Attributes.AddManyAttributes(new Dictionary<string, string> { { "type", "hidden" }, { "name", "scAction" }, { "value", "EloquaFormPost" } });
			form.InsertAfter(scAction, form.FirstChild);
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
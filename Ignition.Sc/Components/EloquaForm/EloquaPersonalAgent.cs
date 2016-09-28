using System;
using System.IO;
using System.Net;
using Ignition.Core.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Extensions;

namespace Ignition.Sc.Components.EloquaForm
{
	public class EloquaPersonalAgent : Agent<EloquaPersonalViewModel>
	{
		public override void PopulateModel()
		{
			var email = AgentContext.HttpContext.Request.Cookies["email"]?.Value;
			if (email.IsEmptyOrNull()) return;
			try
			{
				var request =
					(HttpWebRequest)
						WebRequest.Create($"https://secure.p03.eloqua.com/api/REST/1.0/data/contacts?depth=complete&search={email}");
				request.Headers.Add("Authorization", EloquaAuthHelper.GetAuthString());
				var result = new StreamReader(request.GetResponse().GetResponseStream() ?? new MemoryStream()).ReadToEnd();
				dynamic forminfo = System.Web.Helpers.Json.Decode(result);
				if (forminfo.Elements.Length > 0)
				{
					ViewModel.State = forminfo.Elements[0].Province;
				}
			}
			catch (Exception ex)
			{
				Log.Error("Error processing contact data from Eloqua", ex, this);
			}

		}
	}
}
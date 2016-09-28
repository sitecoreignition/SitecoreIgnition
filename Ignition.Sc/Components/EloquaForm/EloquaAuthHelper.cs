using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using JLL.SP2013.Internet.Eloqua.Client;

namespace Ignition.Sc.Components.EloquaForm
{
	public static class EloquaAuthHelper
	{
		public static string GetAuthString()
		{
			return $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes("perficientpartner\\jon.upchurch:gd151Waite"))}";
		}

		public static EloquaRestServiceClient GetEloquaClient()
		{
			return new EloquaRestServiceClient("perficientpartner", "jon.upchurch", "gd151Waite");
		}
	}
}
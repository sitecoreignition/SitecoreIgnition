using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignition.Core.Models.Settings;
using Ignition.Core.Mvc;
using Ignition.Sc.Components.Shared;

namespace Ignition.Sc.Components.Bookends
{
	public class HeaderViewModel : BaseViewModel
	{
		public IIgnitionPage HomePage { get; set; }
		public IImageSetting Logo { get; set; }
	}
}
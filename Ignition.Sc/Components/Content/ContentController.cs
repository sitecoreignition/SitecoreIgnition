﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Content
{
	public class ContentController: IgnitionController
	{
		public ActionResult FullWidthContent()
		{
			return null;
		}

	    public ActionResult ContentBlurb() => View<ContentBlurbViewModel>();
	}
}
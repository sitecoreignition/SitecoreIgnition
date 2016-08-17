using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignition.Core.Models.Settings;
using Ignition.Core.Mvc;
using Ignition.Sc.Components.Shared;

namespace Ignition.Sc.Components.Bookends
{
	public class HeaderAgent : Agent<HeaderViewModel>
	{
		public override void PopulateModel()
		{
			ViewModel.Logo = AgentContext.Context.GetItem<IImageSetting>("{4675394E-7D66-46BA-93AC-672BC57E6C31}");
			ViewModel.HomePage = AgentContext.Context.GetItem<IIgnitionPage>("{4A442A3D-4FEC-4743-ABBE-621D8A869095}");
		}
	}
}
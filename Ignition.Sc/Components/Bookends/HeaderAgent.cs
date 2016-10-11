using Ignition.Foundation.Core.Models.Settings;
using Ignition.Foundation.Core.Mvc;
using Ignition.Project.IgnitionDemo.Sc.Components.Shared;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Bookends
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
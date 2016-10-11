using Ignition.Foundation.Core.Models.Settings;
using Ignition.Foundation.Core.Mvc;
using Ignition.Project.IgnitionDemo.Sc.Components.Shared;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Bookends
{
	public class HeaderViewModel : BaseViewModel
	{
		public IIgnitionPage HomePage { get; set; }
		public IImageSetting Logo { get; set; }
	}
}
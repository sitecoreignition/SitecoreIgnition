using Ignition.Foundation.Core.Models.Settings;
using Ignition.Foundation.Core.Mvc;
using Ignition.Sc.Components.Shared;

namespace Ignition.Feature.Structure.ViewModels
{
	public class HeaderViewModel : BaseViewModel
	{
		public IIgnitionPage HomePage { get; set; }
		public IImageSetting Logo { get; set; }
	}
}
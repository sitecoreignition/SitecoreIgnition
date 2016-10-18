using Ignition.Feature.Core.Models;
using Ignition.Foundation.Core.Models.Settings;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.Core.ViewModels
{
	public class HeaderViewModel : BaseViewModel
	{
		public IIgnitionPage HomePage { get; set; }
		public IImageSetting Logo { get; set; }
	}
}
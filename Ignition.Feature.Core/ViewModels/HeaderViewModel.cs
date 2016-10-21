using Ignition.Feature.Core.DTOs;
using Ignition.Foundation.Core.Attributes;
using Ignition.Foundation.Core.Models.Settings;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.Core.ViewModels
{
	public class HeaderViewModel : IgnitionViewModel
	{
		public IIgnitionPage HomePage { get; set; }
        [IgnoreAutomap]
        public IImageSetting Logo { get; set; }
	}
}
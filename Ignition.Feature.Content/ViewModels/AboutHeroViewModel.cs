using System.Collections.Generic;
using Ignition.Feature.Content.DTOs;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.ViewModels
{
    public class AboutHeroViewModel : IgnitionViewModel
    {
        public IEnumerable<ILinkedImage> LogoImages { get; set; }
    }
}
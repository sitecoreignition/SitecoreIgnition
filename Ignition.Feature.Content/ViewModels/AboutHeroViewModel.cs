using System.Collections.Generic;
using Ignition.Feature.Content.Models;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.ViewModels
{
    public class AboutHeroViewModel : BaseViewModel
    {
        public IEnumerable<ILinkedImage> LogoImages { get; set; }
    }
}
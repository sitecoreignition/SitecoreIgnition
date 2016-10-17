using System.Collections.Generic;
using Ignition.Feature.Content.Models;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.ViewModels
{
    public class AboutHeroViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }
        public ICopy1 RichContext1 { get; set; }
        public IImage Image { get; set; }
        public IEnumerable<ILinkedImage> LogoImages { get; set; }
    }
}
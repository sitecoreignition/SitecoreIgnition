using System.Collections.Generic;
using Ignition.Core.Mvc;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Hero
{
    public class AboutHeroViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }
        public IRichContent1 RichContext1 { get; set; }
        public IImage Image { get; set; }
        public IEnumerable<ILinkedImage> LogoImages { get; set; }
    }
}
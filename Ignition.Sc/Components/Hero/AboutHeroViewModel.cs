using System.Collections.Generic;
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Hero
{
    public class AboutHeroViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }
        public ICopy1 RichContext1 { get; set; }
        public IImage Image { get; set; }
        public IEnumerable<ILinkedImage> LogoImages { get; set; }
    }
}
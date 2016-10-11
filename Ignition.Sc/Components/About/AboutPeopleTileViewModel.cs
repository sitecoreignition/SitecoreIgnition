using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.About
{
    public class AboutPeopleTileViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }
        public ISubtitle Subtitle { get; set; }
        public IImage Image { get; set; }
        public IPrimaryLink FacebookLink { get; set; }
        public ISecondaryLink GitHubLink { get; set; }
        public ITertiaryLink TumblrLink { get; set; }
    }
}
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.ViewModels
{
    public class AboutPeopleTileViewModel : IgnitionViewModel
    {
        public IHeading Heading { get; set; }
        public ISubtitle Subtitle { get; set; }
        public IImage Image { get; set; }
        public IPrimaryLink FacebookLink { get; set; }
        public ISecondaryLink GitHubLink { get; set; }
        public ITertiaryLink TumblrLink { get; set; }
    }
}
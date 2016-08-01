using Ignition.Core.Mvc;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.About
{
    public class AboutPeopleTileViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }
        public ISubtitle Subtitle { get; set; }
        public IImage Image { get; set; }
    }
}
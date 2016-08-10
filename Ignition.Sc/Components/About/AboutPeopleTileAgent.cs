using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.About
{
    public class AboutPeopleTileAgent : Agent<AboutPeopleTileViewModel>
    {
        public override void PopulateModel()
        {
            var ds = Datasource as IAboutPeopleTile;

            if (ds == null) return;

            ViewModel.Heading = ds;
            ViewModel.Subtitle = ds;
            ViewModel.Image = ds;
        }
    }
}
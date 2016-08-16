using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Hero
{
    public class AboutHeroAgent : Agent<AboutHeroViewModel>
    {
        public override void PopulateModel()
        {
            var ds = Datasource as IAboutHero;

            if (ds == null) return;

            ViewModel.Image = ds;
            ViewModel.Heading = ds;
            ViewModel.RichContext1 = ds;
            ViewModel.LogoImages = ds.LogoImages;
        }
    }
}
using Ignition.Feature.Content.Models;
using Ignition.Feature.Content.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.Content.Agents
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
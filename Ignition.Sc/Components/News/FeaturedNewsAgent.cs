using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.News
{
    public class FeaturedNewsAgent : Agent<FeaturedNewsViewModel>
    {
        public override void PopulateModel()
        {
            var ds = Datasource as IFeaturedNews;
            if (ds == null) return;

            ViewModel.Heading = ds;
            ViewModel.FeatureNewsItems = ds.FeatureNewsItems;
        }
    }
}
using Ignition.Feature.News.Models;
using Ignition.Feature.News.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.News.Agents
{
    public class FeaturedNewsAgent : Agent<FeaturedNewsViewModel>
    {
        public override void PopulateModel()
        {
            var ds = Datasource as IFeaturedNews;
            if (ds == null) return;

            ViewModel.Heading = ds;
            ViewModel.FeatureNewsItems = ds.FeatureNewsItems;
            ViewModel.EditFrameItem = ds;
        }
    }
}
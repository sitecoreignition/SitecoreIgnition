using Ignition.Feature.News.Models;
using Ignition.Feature.News.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.News.Agents
{
    public class LatestNewsAgent : Agent<LatestNewsViewModel>
    {
        public override void PopulateModel()
        {
            var ds = Datasource as ILatestNews;
            if (ds == null) return;

            ViewModel.Heading = ds;
            ViewModel.LatestNewsItems = ds.LatestNewsItems;
            ViewModel.EditFrameItem = ds;
        }
    }
}
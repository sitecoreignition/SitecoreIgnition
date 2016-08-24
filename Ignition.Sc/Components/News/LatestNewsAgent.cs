using System;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.News
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
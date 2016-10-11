using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Product
{
    public class ProductSummaryAgent : Agent<ProductSummaryViewModel>
    {
        public override void PopulateModel()
        {
            var ds = Datasource as IProductSummary;
            if (ds == null) return;

            ViewModel.DateField1 = ds;
            ViewModel.PlainText = ds;
            ViewModel.SingleLineText = ds;
            ViewModel.Heading = ds;
        }
    }
}
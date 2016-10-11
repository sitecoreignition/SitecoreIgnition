using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Product
{
    public class ProductDetailAgent : Agent<ProductDetailsViewModel>
    {
        public override void PopulateModel()
        {
            var ds = Datasource as IProductDetail;

            ViewModel.Heading = ds;
            ViewModel.Image = ds;
            ViewModel.RichContent = ds;
        }
    }
}
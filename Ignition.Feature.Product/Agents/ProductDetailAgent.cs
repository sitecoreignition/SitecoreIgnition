using Ignition.Feature.Product.Models;
using Ignition.Feature.Product.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.Product.Agents
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
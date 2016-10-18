using System.Web.Mvc;
using Ignition.Feature.Product.Agents;
using Ignition.Feature.Product.ViewModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Feature.Product.Controllers
{
    public class ProductController : IgnitionController
    {
        public ActionResult ProductDetail() => View<ProductDetailAgent, ProductDetailsViewModel>();

        public ActionResult ProductSummary() => View<ProductSummaryAgent, ProductSummaryViewModel>();
    }
}
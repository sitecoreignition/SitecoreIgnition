using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Product
{
    public class ProductController : IgnitionController
    {
        public ActionResult ProductDetail() => View<ProductDetailAgent, ProductDetailsViewModel>();

        public ActionResult ProductSummary() => View<ProductSummaryAgent, ProductSummaryViewModel>();
    }
}
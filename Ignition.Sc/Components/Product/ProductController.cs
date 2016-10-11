using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Product
{
    public class ProductController : IgnitionController
    {
        public ActionResult ProductDetail() => View<ProductDetailAgent, ProductDetailsViewModel>();

        public ActionResult ProductSummary() => View<ProductSummaryAgent, ProductSummaryViewModel>();
    }
}
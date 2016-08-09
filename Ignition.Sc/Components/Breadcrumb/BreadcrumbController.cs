using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.Breadcrumb
{
    public class BreadcrumbController : IgnitionController
    {
        public BreadcrumbController(ItemContext context) : base(context)
        {
        }

        public ActionResult Breadcrumb() => View<BreadcrumbViewModel>();
    }
}
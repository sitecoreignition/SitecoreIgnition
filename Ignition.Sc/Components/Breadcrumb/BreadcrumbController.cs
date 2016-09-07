using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Breadcrumb
{
    public class BreadcrumbController : IgnitionController
    {
        public ActionResult Breadcrumb() => View<BreadcrumbViewModel>();
    }
}
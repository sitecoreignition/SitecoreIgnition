using System.Web.Mvc;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Breadcrumb
{
    public class BreadcrumbController : IgnitionController
    {
        public ActionResult Breadcrumb() => View<BreadcrumbViewModel>();
    }
}
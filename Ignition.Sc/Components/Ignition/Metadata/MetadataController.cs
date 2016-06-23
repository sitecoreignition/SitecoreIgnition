using System.Web.Mvc;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Sc.Components.Ignition.Metadata
{
    public class MetadataController : IgnitionController
    {
        public MetadataController(ItemContext context) : base(context)
        {
        }

        public ActionResult Head()
        {
            return View<BaseViewModel>();
        }
        public ActionResult Metadata()
        {
            return View<BaseViewModel>();
        }
        public ActionResult Script()
        {
            return View<BaseViewModel>();
        }
        public ActionResult Seo()
        {
            return View<BaseViewModel>();
        }
        public ActionResult Style()
        {
            return View<BaseViewModel>();
        }
        public ActionResult Taxonomy()
        {
            return View<BaseViewModel>();
        }
        public ActionResult Analytics()
        {
            return View<BaseViewModel>();
        }

        public ActionResult EE()
        {
            return View<BaseViewModel>();
        }
    }
}
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
            return GetViewResult<BaseViewModel>();
        }
        public ActionResult Metadata()
        {
            return GetViewResult<BaseViewModel>();
        }
        public ActionResult Script()
        {
            return GetViewResult<BaseViewModel>();
        }
        public ActionResult Seo()
        {
            return GetViewResult<BaseViewModel>();
        }
        public ActionResult Style()
        {
            return GetViewResult<BaseViewModel>();
        }
        public ActionResult Taxonomy()
        {
            return GetViewResult<BaseViewModel>();
        }
        public ActionResult Analytics()
        {
            return GetViewResult<BaseViewModel>();
        }

        public ActionResult EE()
        {
            return GetViewResult<BaseViewModel>();
        }
    }
}
﻿using System.Web.Mvc;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Metadata
{
    public class MetadataController : IgnitionController
    {
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

        public ActionResult PageEdit()
        {
            return View<BaseViewModel>();
        }
    }
}
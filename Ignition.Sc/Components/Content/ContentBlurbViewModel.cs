using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignition.Core.Mvc;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Content
{
    public class ContentBlurbViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }

        public ICopy1 Copy1 { get; set; }
    }
}
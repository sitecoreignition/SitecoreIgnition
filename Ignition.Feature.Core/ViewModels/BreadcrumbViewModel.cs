using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Core.ViewModels
{
    public class BreadcrumbViewModel : IgnitionViewModel
    {
        public IHeading Heading { get; set; }
    }
}
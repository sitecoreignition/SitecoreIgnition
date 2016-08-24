using Ignition.Core.Mvc;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Product
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        public IImage Image { get; set; }

        public IHeading Heading { get; set; }

        public IRichContent1 RichContent { get; set; }
    }
}
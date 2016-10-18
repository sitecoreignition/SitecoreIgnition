using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Product.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        public IImage Image { get; set; }

        public IHeading Heading { get; set; }

        public ICopy1 RichContent { get; set; }
    }
}
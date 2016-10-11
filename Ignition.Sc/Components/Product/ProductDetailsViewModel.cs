using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Product
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        public IImage Image { get; set; }

        public IHeading Heading { get; set; }

        public ICopy1 RichContent { get; set; }
    }
}
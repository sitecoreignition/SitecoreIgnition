using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Product.ViewModels
{
    public class ProductSummaryViewModel : IgnitionViewModel
    {
        public IHeading Heading { get; set; }

        public IDateField1 DateField1 { get; set; }

        public ISingleLineText SingleLineText { get; set; }

        public ICopy1 PlainText { get; set; }
    }
}
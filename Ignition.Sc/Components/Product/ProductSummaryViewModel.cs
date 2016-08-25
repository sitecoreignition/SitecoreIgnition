using Ignition.Core.Mvc;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Product
{
    public class ProductSummaryViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }

        public IDateField1 DateField1 { get; set; }

        public ISingleLineText SingleLineText { get; set; }

        public IPlainText PlainText { get; set; }
    }
}
using Ignition.Foundation.Core.Mvc;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Product
{
    public class ProductSummaryViewModel : BaseViewModel
    {
        public IHeading Heading { get; set; }

        public IDateField1 DateField1 { get; set; }

        public ISingleLineText SingleLineText { get; set; }

        public IPlainText PlainText { get; set; }
    }
}
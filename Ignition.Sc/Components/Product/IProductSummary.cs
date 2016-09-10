using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Product
{
    [SitecoreType(TemplateId = "{F9BD3BA6-3836-453A-8B91-01E45F53EA75}", AutoMap = true)]
    public interface IProductSummary : IPlainText, IDateField1, ISingleLineText, IHeading
    {
    }
}

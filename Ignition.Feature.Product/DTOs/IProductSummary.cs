using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Product.Models
{
    [SitecoreType(TemplateId = "{F9BD3BA6-3836-453A-8B91-01E45F53EA75}", AutoMap = true)]
    public interface IProductSummary : ICopy1, IDateField1, ISingleLineText, IHeading
    {
    }
}

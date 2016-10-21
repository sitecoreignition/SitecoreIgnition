using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Product.Models
{
    [SitecoreType(TemplateId = "{98381402-F597-4654-8ECB-B881D88F542D}", AutoMap = true)]
    public interface IProductDetail : IImage, IHeading, ICopy1, IDateField1, ISingleLineText, ICopy2
    {     
    }
}
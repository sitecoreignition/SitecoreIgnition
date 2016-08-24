using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Product
{
    [SitecoreType(TemplateId = "{98381402-F597-4654-8ECB-B881D88F542D}", AutoMap = true)]
    public interface IProductDetail : IImage, IHeading, IRichContent1, IDateField1, ISingleLineText, IPlainText
    {     
    }
}
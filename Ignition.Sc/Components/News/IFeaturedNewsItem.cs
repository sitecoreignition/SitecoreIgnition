using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.News
{
    [SitecoreType(TemplateId = "{99E7D94B-A2DD-46B7-8647-93ACB54D9BFC}", AutoMap = true)]
    public interface IFeaturedNewsItem : IDateField1, IImage, IHeading, IPrimaryLink, IPlainText
    { 
    }
}
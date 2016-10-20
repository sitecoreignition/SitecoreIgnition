using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.News.Models
{
    [SitecoreType(TemplateId = "{99E7D94B-A2DD-46B7-8647-93ACB54D9BFC}", AutoMap = true)]
    public interface IFeaturedNewsItem : IDateField1, IImage, IHeading, IPrimaryLink, ICopy1
    { 
    }
}
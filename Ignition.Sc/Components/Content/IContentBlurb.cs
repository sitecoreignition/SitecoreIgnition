using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Content
{
    [SitecoreType(TemplateId = "{5ED0D95D-4169-4F3F-AC9A-5B30B99E06B1}", AutoMap = true)]
    public interface IContentBlurb : IHeading, ICopy1
    {   
    }
}
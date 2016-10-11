using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Hero
{
    [SitecoreType(TemplateId = "{97F58184-24C4-4296-979E-288AA210BC69}", AutoMap = true)]
    public interface ILinkedImage : IImage, IPrimaryLink
    {
    }
}

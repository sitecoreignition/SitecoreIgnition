using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.About
{
    [SitecoreType(TemplateId = "{D7DD8BED-9750-4FE6-887E-0FEB15F9DFB3}", AutoMap = true)]
    public interface IAboutPeopleTile : IHeading, IImage, ISubtitle
    {      
    }
}
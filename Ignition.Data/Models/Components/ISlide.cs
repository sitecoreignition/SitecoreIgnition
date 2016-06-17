using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Data.Models.Components
{
    [SitecoreType(TemplateId = "{B0E9B25B-8826-4F96-A393-37B805C86C23}")]
    public interface ISlide : IRichContent1, IHeading, IBackgroundImage, IBoolean
    {

    }
}

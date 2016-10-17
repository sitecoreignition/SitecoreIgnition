using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.Content.Models
{
    [SitecoreType(TemplateId = "{1EE6B463-AB7D-4364-8526-2A2477928E4E}", AutoMap = true)]
    public interface IAboutPeopleTile : IHeading, IImage, ISubtitle, IPrimaryLink, ISecondaryLink, ITertiaryLink
    {      
    }
}
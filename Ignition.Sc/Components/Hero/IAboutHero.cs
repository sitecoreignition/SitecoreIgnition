using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Hero
{
    [SitecoreType(TemplateId = "{6538AB6D-3016-4708-8800-0735967EA67F}", AutoMap = true)]
    public interface IAboutHero : IHeading, IImage, IRichContent1
    {
        [SitecoreField(FieldId = "{07DF7C11-7EA7-4739-8FE5-9A3DA7067163}", Setting = SitecoreFieldSettings.InferType)]
        IEnumerable<ILinkedImage> LogoImages { get; set; }
    }
}
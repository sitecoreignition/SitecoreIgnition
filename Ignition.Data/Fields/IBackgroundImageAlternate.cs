using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{D5BF5E98-55F0-4DA4-AA17-14E56E2AF263}")]
    public interface IBackgroundImageAlternate : IModelBase
    {
        [SitecoreField(FieldId = "{BEBCE4EB-0F82-402C-B694-A21F9F0B194D}")]
        Image BackgroundImageAlternate { get; set; }
    }
}
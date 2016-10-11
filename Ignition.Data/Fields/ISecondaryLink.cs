using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{C330D166-687F-48C1-8FBC-47DE306D34D6}", AutoMap = true)]
    public interface ISecondaryLink : IModelBase
    {
        [SitecoreField(FieldId = "{DE3F5373-4370-4702-972D-CFD73F88EA63}")]
        Link SecondaryLink { get; set; }
    }
}
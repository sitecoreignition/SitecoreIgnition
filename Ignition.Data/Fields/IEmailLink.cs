using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{51D2D2E9-5C3F-4839-80F6-FD5601369633}", AutoMap = true)]
    public interface IEmailLink : IModelBase
    {
        [SitecoreField(FieldId = "{85FAA050-AAF1-4195-9F2D-688E22C4B2DF}")]
        Link EmailLink { get; set; }
    }
}
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models;

namespace Ignition.Data.Fields
{
    [SitecoreType(TemplateId = "{4C1EB66B-798D-4D31-A6BB-D7CBB4405057}")]
    public interface IRichContent2 : IModelBase
    {
        [SitecoreField(FieldId = "{E067A172-899E-4E61-A813-C56A42D4CF86}")]
        string RichText2 { get; set; }
    }
}
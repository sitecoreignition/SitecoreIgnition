using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{4C1EB66B-798D-4D31-A6BB-D7CBB4405057}")]
    public interface ICopy2 : IModelBase
    {
        [SitecoreField(FieldId = "{E067A172-899E-4E61-A813-C56A42D4CF86}")]
        string Copy2 { get; set; }
    }
}
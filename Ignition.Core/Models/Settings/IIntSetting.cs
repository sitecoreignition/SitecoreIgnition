using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Settings
{
    [SitecoreType(TemplateId = "{9A7616B4-3CB5-4351-9561-E363C7100154}")]
    public interface IIntSetting : IModelBase
    {
        [SitecoreField(FieldId = "{E3DB7E64-7718-4B64-9E98-5C3D1245D8DC}")]
        int IntSetting { get; set; }
    }
}

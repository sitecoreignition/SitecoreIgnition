using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{841E14B7-B05E-46EF-B17F-98046A6E661D}")]
    public interface IBoolean : IModelBase
    {
        [SitecoreField(FieldId = "{8D5472EE-5C3D-406F-942B-11CC74A2372C}")]
        bool Checkbox { get; set; }
    }
}
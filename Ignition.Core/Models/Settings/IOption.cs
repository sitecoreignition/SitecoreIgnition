using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Settings
{
    [SitecoreType(TemplateId = "{2251DD1D-6255-428F-B751-9AFB34F20AFA}", AutoMap = true)]
    public interface IOption : IModelBase
    {
        [SitecoreField(FieldId = "{EC72E24F-7C28-4E95-8D0B-F165D1004792}")]
        string DataValue { get; set; }
    }
}

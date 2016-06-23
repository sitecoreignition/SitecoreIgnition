using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Core.Models.Settings
{
    [SitecoreType(TemplateId = "{4DCC294F-D5EC-4607-917A-E4A3B80EC624}")]
    public interface IStringSetting : IModelBase
    {
        [SitecoreField(FieldId = "{0DBDC181-2CD0-4FEA-B8F1-763888684F41}")]
        string StringSetting { get; set; }
    }
}

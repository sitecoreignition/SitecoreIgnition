using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Core.Models.System
{
    [SitecoreType(TemplateId = "{6D1CD897-1936-4A3A-A511-289A94C2A7B1}")]
    public interface IDictionaryEntry : IModelBase
    {
        string Key { get; set; }
        string Phrase { get; set; }
    }
}
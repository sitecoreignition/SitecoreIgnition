using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{85308FC9-E558-4B44-96BA-036C7FDA356C}")]
    public interface IImage : IModelBase
    {
        [SitecoreField(FieldId = "{5467C5AF-07CF-4600-89E4-B1842761DC3F}")]
        Image Image { get; set; }
    }
}
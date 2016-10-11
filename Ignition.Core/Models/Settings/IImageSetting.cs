using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Settings
{
    [SitecoreType(TemplateId = "{5546A63F-AA8D-43C5-ABAE-C89518085558}")]
    public interface IImageSetting : IModelBase
    {
        [SitecoreField(FieldId = "{1F4F6A33-9831-4323-B879-96AF88745183}")]
        Image ImageSetting { get; set; }
    }
}

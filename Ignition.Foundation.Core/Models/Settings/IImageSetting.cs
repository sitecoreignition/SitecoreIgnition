using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Settings
{
    public interface IImageSetting : IModelBase
    {
        Image ImageSetting { get; set; }
    }
}

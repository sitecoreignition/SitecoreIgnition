using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Settings
{
    public interface IIntSetting : IModelBase
    {
        int IntSetting { get; set; }
    }
}

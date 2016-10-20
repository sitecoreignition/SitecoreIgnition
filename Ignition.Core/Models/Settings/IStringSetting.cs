using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Settings
{
    public interface IStringSetting : IModelBase
    {
        string StringSetting { get; set; }
    }
}

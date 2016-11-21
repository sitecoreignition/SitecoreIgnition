using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Settings
{
    public interface IDecimalSetting : IModelBase
    {
        decimal DecimalSetting { get; set; }
    }
}

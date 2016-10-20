using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Settings
{
    public interface IOption : IModelBase
    {
        string DataValue { get; set; }
    }
}

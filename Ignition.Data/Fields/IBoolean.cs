using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    public interface IBoolean : IModelBase
    {
        bool Checkbox { get; set; }
    }
}
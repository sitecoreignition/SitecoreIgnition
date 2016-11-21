using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    public interface ISingleReference : IModelBase
    {
        IModelBase ReferencedItem { get; set; }
    }
}
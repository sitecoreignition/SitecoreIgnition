using System.Collections.Generic;

namespace Ignition.Foundation.Core.Models.BaseModels
{
    public interface INeedsChildren : IModelBase
    {
        IEnumerable<IModelBase> BaseChildren { get; set; }
    }
}
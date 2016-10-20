using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Foundation.Core.Models.BaseModels
{
    public interface INeedsChildren
    {
        IEnumerable<IModelBase> BaseChildren { get; set; }
    }
}
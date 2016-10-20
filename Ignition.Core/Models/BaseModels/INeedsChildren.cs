using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.Mappers;

namespace Ignition.Foundation.Core.Models.BaseModels
{
    public interface INeedsChildren
    {
        IEnumerable<IModelBase> BaseChildren { get; set; }
    }
}
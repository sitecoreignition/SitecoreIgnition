using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Core.Models.BaseModels
{
    [SitecoreType]
    public interface INeedsChildren
    {
        [SitecoreChildren(IsLazy = false, InferType = true)]
        IEnumerable<IModelBase> BaseChildren { get; set; }
    }
}
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Foundation.Core.Models.BaseModels
{
    [SitecoreType]
    public interface INeedsChildren
    {
        [SitecoreChildren(IsLazy = false, InferType = true)]
        IEnumerable<IModelBase> BaseChildren { get; set; }
    }
}
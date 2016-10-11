using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Foundation.Core.Models.BaseModels
{
    [SitecoreType]
    public interface INeedsParent
    {
        [SitecoreParent(InferType = true)]
        IModelBase Parent { get; set; }
    }
}
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.System
{
    public interface IFolder : IModelBase, INeedsChildren, INeedsParent
    {
    }
}
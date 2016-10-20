using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Page
{
    public interface IPage :  IMetadata, INavigation, ITaxonomy, INeedsChildren, IModelBaseWithMetadata, INeedsParent
    {

	}
}
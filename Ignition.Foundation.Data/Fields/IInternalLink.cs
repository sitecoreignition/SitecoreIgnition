using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    public interface IInternalLink : IModelBase
    {
        Link InternalLink { get; set; }
    }
}
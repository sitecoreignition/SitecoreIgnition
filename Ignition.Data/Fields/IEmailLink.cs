using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    public interface IEmailLink : IModelBase
    {
        Link EmailLink { get; set; }
    }
}
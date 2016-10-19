using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Page
{
    public interface IMetadata : IModelBase
    {
        string PageTitle { get; set; }
        string PageDescription { get; set; }
    }
}
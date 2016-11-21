using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    public interface IBackgroundImageAlternate : IModelBase
    {
        Image BackgroundImageAlternate { get; set; }
    }
}
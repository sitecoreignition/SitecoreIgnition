using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Page
{
    public interface INavigation : IModelBase
    {
        string NavigationTitle { get; set; }
        bool HideFromNavigation { get; set; }
        bool HideChildrenFromNavigation { get; set; }
    }
}
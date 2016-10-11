using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.System
{
    [SitecoreType(TemplateId = "{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}")]
    public interface IFolder : IModelBase, INeedsChildren
    {
    }
}
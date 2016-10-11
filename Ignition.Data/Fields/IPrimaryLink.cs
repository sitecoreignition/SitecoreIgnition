using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{60A77BBE-C64E-4BD8-AAE1-31B5A8E8AFE5}")]
    public interface IPrimaryLink : IModelBase
    {
        [SitecoreField(FieldId = "{253D5C6D-81BD-4C53-8552-3C8D603682F4}")]
        Link PrimaryLink { get; set; }
    }
}
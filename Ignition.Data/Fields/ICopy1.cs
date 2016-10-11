using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{0F38D202-D47C-4E9A-93E5-3B535AB63CF0}")]
    public interface ICopy1 : IModelBase
    {
        [SitecoreField(FieldId = "{A3513117-630A-4830-86C0-A2F15164BE04}")]
        string Copy1 { get; set; }
    }
}
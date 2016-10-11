using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{D6BC5A2C-7E68-4D82-B20E-5F8EE0D51E41}")]
    public interface ISingleReference : IModelBase
    {
        [SitecoreField(FieldId = "{8475E803-D40B-4AE3-8443-BEB1C047412D}")]
        IModelBase ReferencedItem { get; set; }
    }
}
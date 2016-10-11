using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{C4B8AA9E-BB14-439A-951D-F2B1D8600897}")]
    public interface IImage2 : IModelBase
    {
        [SitecoreField(FieldId = "{EE230F5E-665E-46A3-9BC7-2416212212EA}")]
        Image Image2 { get; set; }
    }
}
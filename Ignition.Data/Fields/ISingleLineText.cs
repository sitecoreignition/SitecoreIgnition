using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{D1AEF8A0-99FC-4090-8F9B-79EC12B52116}", AutoMap = true)]
    public interface ISingleLineText : IModelBase
    {
        [SitecoreField(FieldId = "{BB51FAF2-0A09-47E0-AE5C-3D8DA64C6C40}")]
        string SingleLineText { get; set; }
    }
}
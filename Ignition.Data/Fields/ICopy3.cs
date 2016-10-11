using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{5F8D5E76-8178-43AA-BE0D-AA8F34472FEC}")]
    public interface ICopy3 : IModelBase
    {
        [SitecoreField(FieldId = "{8475E803-D40B-4AE3-8443-BEB1C047412D}", Setting = SitecoreFieldSettings.RichTextRaw)]
        string Copy3 { get; set; }
    }
}
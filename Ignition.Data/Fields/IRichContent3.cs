using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models;

namespace Ignition.Data.Fields
{
    [SitecoreType(TemplateId = "{5F8D5E76-8178-43AA-BE0D-AA8F34472FEC}")]
    public interface IRichContent3 : IModelBase
    {
        [SitecoreField(FieldId = "{3B967640-6084-41FD-9B79-AF6F6C145F83}", Setting = SitecoreFieldSettings.RichTextRaw)]
        string RichText1 { get; set; }

        [SitecoreField(FieldId = "{B85705F6-9975-4E76-A468-C5C2B24114FC}", Setting = SitecoreFieldSettings.RichTextRaw)]
        string RichText2 { get; set; }

        [SitecoreField(FieldId = "{8475E803-D40B-4AE3-8443-BEB1C047412D}", Setting = SitecoreFieldSettings.RichTextRaw)]
        string RichText3 { get; set; }
    }
}
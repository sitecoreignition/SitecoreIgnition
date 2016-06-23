using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Data.Fields
{
    [SitecoreType(TemplateId = "{F92858EF-FD23-4B23-91FF-5F2517DCF5BB}")]
    public interface IPlainText : IModelBase
    {
        [SitecoreField(FieldId = "{A5ED8087-86D9-47BE-86DC-1F9C607164C0}")]
        string PlainText { get; set; }
    }
}
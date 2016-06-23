using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Data.Fields
{
    [SitecoreType(TemplateId = "{F89F2500-DF04-4FF8-B33A-FD58F331415C}")]
    public interface ISubtitle : IModelBase
    {
        [SitecoreField(FieldId = "{3487FEB5-9DAB-49AA-B9DF-F97A877BA7ED}")]
        string Subtitle { get; set; }
    }
}
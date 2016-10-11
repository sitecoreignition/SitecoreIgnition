using System;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{AA715605-C3E3-46EC-BDCB-CBB1365E0D1B}")]
    public interface IDateField1 : IModelBase
    {
        [SitecoreField(FieldId = "{FF8D378C-E9DA-4D74-8913-17D1D729BF2C}")]
        DateTime DateField1 { get; set; }
    }
}
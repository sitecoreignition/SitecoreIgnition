using System;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{E4606498-4A6D-4C37-BEA7-7C50973C9C8C}")]
    public interface IDateField2 : IModelBase
    {
        [SitecoreField(FieldId = "{B1AC24A8-141D-4CEC-8009-38606F8BC160}")]
        DateTime DateField2 { get; set; }
    }
}
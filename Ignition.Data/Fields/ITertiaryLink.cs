using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{2F5EB1F5-E5DA-46B2-9AE4-8824501BB81A}", AutoMap = true)]
    public interface ITertiaryLink : IModelBase
    {
        [SitecoreField(FieldId = "{9CF29720-7AF2-4941-9EED-E436B42F681D}")]
        Link TertiaryLink { get; set; }
    }
}
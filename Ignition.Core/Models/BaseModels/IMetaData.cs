using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Core.Models.BaseModels
{
    [SitecoreType(TemplateId = "{2C0AB971-113B-4206-988B-DE77BE43E70D}", AutoMap = true)]
    public interface IMetadata : IModelBase
    {
        [SitecoreField(FieldId = "{D273DA81-EF49-406F-86E5-163FFFA26671}")]
        string PageTitle { get; set; }

        [SitecoreField(FieldId = "{75D7908F-85A8-4B47-80D8-4243B658DF24}")]
        string PageDescription { get; set; }
    }
}
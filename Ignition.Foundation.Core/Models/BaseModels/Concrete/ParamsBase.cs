using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Foundation.Core.Models.BaseModels.Concrete
{
    [SitecoreType(AutoMap = true, TemplateId = "{20FCB4C8-F9B2-41F6-9464-16BCC280ADC0}")]
    public class ParamsBase : ModelBase, IParamsBase
    {
        [SitecoreField(FieldId = "{FBA99685-DC80-45A7-B450-8DB4B74A6582}")]
        public string PlaceHolderName { get; set; }
    }
}

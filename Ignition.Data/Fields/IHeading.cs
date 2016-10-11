using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{6CDD0A6B-9598-4504-89A6-FACD76D6AF29}", AutoMap = true)]
    public interface IHeading : IModelBase
    {
        [SitecoreField(FieldId = "{7DD87307-F0D1-4C76-B9D2-BACAF51AE316}")]
        string Heading { get; set; }
    }
}
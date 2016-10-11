using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{DF4EEF4E-4099-4EC3-BDB3-154EFE0648C4}", AutoMap = true)]
    public interface IBackgroundImage : IModelBase
    {
        [SitecoreField(FieldId = "{688BBA82-CEB0-4EDD-9D32-AD0EA1F8F8F9}")]
        Image BackgroundImage { get; set; }
    }
}
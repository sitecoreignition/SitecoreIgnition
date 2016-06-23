using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Data.Fields
{
    [SitecoreType(TemplateId = "{27513B78-99D5-4E43-B285-67F7F1E218C5}")]
    public interface ILogo : IModelBase
    {
        [SitecoreField(FieldId = "{3B9EC70E-DD65-4129-BCE6-75B997902BE4}")]
        Image Logo { get; set; }
    }
}
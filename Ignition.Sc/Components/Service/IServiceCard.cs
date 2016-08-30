using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.Settings;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Service
{
    [SitecoreType(TemplateId = "", AutoMap = true)]
    public interface IServiceCard : IHeading, IPlainText
    {
        [SitecoreField(FieldId = "", Setting = SitecoreFieldSettings.InferType)]
        IStringSetting IconClass { get; set; }      
    }
}
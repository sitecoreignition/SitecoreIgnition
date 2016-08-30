using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.Settings;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Service
{
    [SitecoreType(TemplateId = "{319DE28B-2587-4356-8D5D-F2204858FC71}", AutoMap = true)]
    public interface IServiceCard : IHeading, IPlainText, ISingleLineText
    {
        [SitecoreField(FieldId = "{4391DED9-8C09-448F-8C3F-6D5C56A57DFF}", Setting = SitecoreFieldSettings.InferType)]
        IStringSetting IconClass { get; set; }      
    }
}
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Data.Fields
{
    [SitecoreType(TemplateId = "{7E31C746-7AF6-485F-9437-BD4ADE415EA3}", AutoMap = true)]
    public interface IAbstract : IModelBase
    {
        [SitecoreField(FieldId = "{13BA7DE9-6997-44AA-BA9F-36B16D41CE45}", Setting = SitecoreFieldSettings.RichTextRaw)]
        string Abstract { get; set; }
    }
}
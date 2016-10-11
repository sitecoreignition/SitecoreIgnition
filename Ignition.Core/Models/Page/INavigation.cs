using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.Page
{
    [SitecoreType(TemplateId = "{4B39EFA4-00EB-4C61-BD45-82FB2C72E810}", AutoMap = true)]
    public interface INavigation : IModelBase
    {
        [SitecoreField(FieldId = "{56666E5E-AFB9-49F6-A950-1D065B9FE35C}")]
        string NavigationTitle { get; set; }

        [SitecoreField(FieldId = "{786A89D2-AE2B-4C3C-9855-58A64A204E02}")]
        bool HideFromNavigation { get; set; }

        [SitecoreField(FieldId = "{A0537A65-7327-4BB3-ACAB-ED22E739DEBE}")]
        bool HideChildrenFromNavigation { get; set; }

        [SitecoreField(FieldId = "{A644EFEB-7442-46FD-B149-FE0D7E36F0A8}")]
        Link OverrideLink { get; set; }

        [SitecoreField(FieldId = "{53F083A0-072F-412A-BAC5-2A01CBAB8688}")]
        bool ShowMore { get; set; }
    }
}
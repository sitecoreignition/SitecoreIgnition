using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.News.Models
{
    [SitecoreType(TemplateId = "{A3D6BEA6-8A51-4301-AD06-56DF0910B811}", AutoMap = true)]
    public interface IFeaturedNews : IHeading
    {
        [SitecoreField(FieldId = "{AA9CC7EB-BA10-4EDC-BE9C-035DB430E5ED}", Setting = SitecoreFieldSettings.InferType)]
        IEnumerable<IFeaturedNewsItem> FeatureNewsItems { get; set; }
    }
}
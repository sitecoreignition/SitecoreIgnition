using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Feature.News.Models
{
    [SitecoreType(TemplateId = "{B26FD8DB-84D5-4C57-B092-FDE37A0AC553}", AutoMap = true)]
    public interface ILatestNews : IHeading
    {
        [SitecoreField(FieldId = "{480CFEB3-632C-4EEA-B111-2F6DF640B045}", Setting = SitecoreFieldSettings.InferType)]
        IEnumerable<ILatestNewsItem> LatestNewsItems { get; set; }
    }
}
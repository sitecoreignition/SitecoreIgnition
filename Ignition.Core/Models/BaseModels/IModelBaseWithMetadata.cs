using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;

namespace Ignition.Foundation.Core.Models.BaseModels
{
    [SitecoreType]
    public interface IModelBaseWithMetadata
    {
        string Sortorder { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
        string FullUrl { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId), IndexField("_template")]
        Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateName), IndexField("_templatename")]
        string TemplateName { get; set; }
    }
}
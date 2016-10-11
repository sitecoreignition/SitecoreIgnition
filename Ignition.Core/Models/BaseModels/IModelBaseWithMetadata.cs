using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;

namespace Ignition.Foundation.Core.Models.BaseModels
{
    [SitecoreType]
    public interface IModelBaseWithMetadata
    {
        [SitecoreField("__Sortorder"), IndexField("__Sortorder")]
        string Sortorder { get; set; }

        [SitecoreField("__created"), IndexField("__created")]
        DateTime Created { get; set; }

        [SitecoreField("__updated"), IndexField("__updated")]
        DateTime Updated { get; set; }

        [IndexField("_fullpath")]
        string FullPath { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url,
            UrlOptions = SitecoreInfoUrlOptions.AlwaysIncludeServerUrl | SitecoreInfoUrlOptions.LanguageEmbeddingNever)]
        string FullUrl { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId), IndexField("_template")]
        Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateName), IndexField("_templatename")]
        string TemplateName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.Globalization;

namespace Ignition.Core.Models
{
    [SitecoreType(TemplateId = "{4C3CDC24-1610-4808-92A3-A221768AE3B2}",AutoMap = true)]
    public interface IModelBase : IComparable<IModelBase>, IEquatable<IModelBase>
    {
        [SitecoreId, IndexField("_group")]
        Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Language), IndexField("_language")]
        Language Language { get; set; }

        [TypeConverter(typeof (IndexFieldItemUriValueConverter)), XmlIgnore, IndexField("_uniqueid")]
        ItemUri Uri { get; set; }

        [SitecoreInfo(SitecoreInfoType.DisplayName)]
        string DisplayName { get; set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        int Version { get; }

        [SitecoreInfo(SitecoreInfoType.Path), IndexField("_path")]
        string Path { get; set; }

        [IndexField("_fullpath")]
        string FullPath { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name), IndexField("_name")]
        string Name { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.LanguageEmbeddingNever)]
        string Url { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.AlwaysIncludeServerUrl | SitecoreInfoUrlOptions.LanguageEmbeddingNever)]
        string FullUrl { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId), IndexField("_template")]
        Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateName), IndexField("_templatename")]
        string TemplateName { get; set; }

        [SitecoreChildren(IsLazy = false, InferType = true)]
        IEnumerable<IModelBase> BaseChildren { get; set; }

        [SitecoreParent(InferType = true)]
        IModelBase Parent { get; set; }

        [SitecoreField("__Sortorder"), IndexField("__Sortorder")]
        string Sortorder { get; set; }

        [SitecoreField("__created"), IndexField("__created")]
        DateTime Created { get; set; }

        [SitecoreField("__updated"), IndexField("__updated")]
        DateTime Updated { get; set; }
    }
}
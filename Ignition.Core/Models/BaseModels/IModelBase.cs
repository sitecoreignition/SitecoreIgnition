using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.Globalization;

namespace Ignition.Core.Models.BaseModels
{
    [SitecoreType(TemplateId = "{4C3CDC24-1610-4808-92A3-A221768AE3B2}", AutoMap = true)]
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

        [SitecoreInfo(SitecoreInfoType.Name), IndexField("_name")]
        string Name { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.LanguageEmbeddingNever)]
        string Url { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ModelBase : IModelBase
    {
        [SitecoreId, IndexField("_group")]
        public virtual Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Language), IndexField("_language")]
        public virtual Language Language { get; set; }

        [TypeConverter(typeof(IndexFieldItemUriValueConverter)), XmlIgnore, IndexField("_uniqueid")]
        public virtual ItemUri Uri { get; set; }

        [SitecoreInfo(SitecoreInfoType.DisplayName)]
        public virtual string DisplayName { get; set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        public virtual int Version { get; set; }

        [SitecoreInfo(SitecoreInfoType.Path), IndexField("_path")]
        public virtual string Path { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name), IndexField("_name")]
        public virtual string Name { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.LanguageEmbeddingNever)]
        public virtual string Url { get; set; }

        public int CompareTo(IModelBase other)
        {
            return Id.CompareTo(other.Id);
        }

        public bool Equals(IModelBase other)
        {
            return Id.Equals(other.Id);
        }
    }
}

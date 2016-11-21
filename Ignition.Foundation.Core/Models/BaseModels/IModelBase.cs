using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Globalization;

namespace Ignition.Foundation.Core.Models.BaseModels
{
    public interface IModelBase
    {
        Guid Id { get; set; }
        Language Language { get; set; }
        string DisplayName { get; set; }
        int Version { get; set; }
        string Path { get; set; }
        string Name { get; set; }
        string Url { get; set; }
    }
}
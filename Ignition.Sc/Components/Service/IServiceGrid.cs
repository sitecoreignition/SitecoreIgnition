using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Sc.Components.Service
{
    [SitecoreType(TemplateId = "", AutoMap = true)]
    public interface IServiceGrid : IModelBase
    {
         [SitecoreField(FieldId = "", Setting = SitecoreFieldSettings.InferType)]
         IEnumerable<IServiceCard> ServiceCards { get; set; }
    }
}
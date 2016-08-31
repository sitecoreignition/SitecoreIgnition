using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Sc.Components.Service
{
    [SitecoreType(TemplateId = "{B14C314D-28EB-48EB-A39F-D52131C8D404}", AutoMap = true)]
    public interface IServiceGrid : IModelBase
    {
         [SitecoreField(FieldId = "{7BAED51E-FED4-4E7F-9D78-9C218C1B5E37}", Setting = SitecoreFieldSettings.InferType)]
         IEnumerable<IServiceCard> ServiceCards { get; set; }
    }
}
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Foundation.Core.Models.Page
{
    [SitecoreType(TemplateId = "{1522097B-B91D-4E98-BBDB-AD197619765D}", AutoMap = true)]
    public interface ITaxonomy : IModelBase
    {
        [SitecoreField(FieldId = "{2E701CF5-4C90-4E03-A6E1-21696E166311}")]
        IEnumerable<IOption> Tags { get; set; }
    }
}
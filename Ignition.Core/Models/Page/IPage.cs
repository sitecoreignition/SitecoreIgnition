using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Core.Models.BaseModels;

namespace Ignition.Core.Models.Page
{
    [SitecoreType(TemplateId = "{0935636A-EE07-442D-8930-87EC0CAE26A4}")]
    public interface IPage :  IMetadata, INavigation, ITaxonomy, INeedsChildren, IModelBaseWithMetadata
    {

	}
}
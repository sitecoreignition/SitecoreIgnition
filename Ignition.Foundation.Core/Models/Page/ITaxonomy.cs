using System.Collections.Generic;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Foundation.Core.Models.Page
{
    public interface ITaxonomy : IModelBase
    {
        IEnumerable<IOption> Tags { get; set; }
    }
}
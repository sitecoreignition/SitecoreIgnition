using System.Collections.Generic;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Feature.Core.DTOs
{
	public interface IBootstrapColumns : IParamsBase
	{
		IEnumerable<IOption> ColumnClasses { get; set; }
	}
}

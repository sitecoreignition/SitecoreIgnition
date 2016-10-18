using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Settings;

namespace Ignition.Feature.Core.Models
{
	[SitecoreType(TemplateId = "{6F674EF0-9E3A-4EFF-A956-6F40DA4AFA36}", AutoMap = true)]
	public interface IBootstrapColumns : IParamsBase
	{
		IEnumerable<IOption> ColumnClasses { get; set; }
	}
}

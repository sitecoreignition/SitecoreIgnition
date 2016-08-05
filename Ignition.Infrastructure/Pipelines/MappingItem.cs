using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.Infrastructure.Pipelines
{
	public class MappingItem
	{
		public string TemplateName { get; set; }
		public Dictionary<string,string> FieldMaps { get; set; }
	}
}

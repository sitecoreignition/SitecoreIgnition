using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Ignition.Infrastructure.Pipelines
{
    public class YmlSettingsReader
    {
	    public YmlSettingsReader()
	    {
			var reader = new StringReader(Document);
			var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
			var maps = deserializer.Deserialize<TemplateMap>(reader);
		}

	    private const string Document = @"---
            TemplateMap:
				- TemplateItem: 
					-TemplateName: CallToAction
					MapItems:
						- FieldName: Heading
						MapTo: Title
						- FieldName: Subtitle
						MapTo: Subheading
			";
    }
}
public class TemplateMap
{
	private List<TemplateItem> TemplateItems { get; set; }
}

public class MapItem
{
	public string FieldName { get; set; }
	public string MapTo { get; set; }
}

public class TemplateItem
{
	public string TemplateName { get; set; }
	public List<MapItem> MapItems { get; set; }
}
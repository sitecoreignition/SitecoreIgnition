using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Ignition.Infrastructure.Pipelines
{
	public class YmlSettingsReader
	{
		public static void Main(string[] args)
		{
			var item = new YmlSettingsReader();
		}
		public TemplateMap TemplateMap { get; set; }
		public YmlSettingsReader()
		{
			var reader = new StringReader(File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Config/FieldSettings.yml")));
			var deserializer = new Deserializer();
			TemplateMap = deserializer.Deserialize<TemplateMap>(reader);
		}
	}
}
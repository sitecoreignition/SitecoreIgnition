using System.IO;
using System.Web;
using YamlDotNet.Serialization;

namespace Ignition.Foundation.Infrastructure.Pipelines
{
	public static class YmlSettingsReader
	{
		private static TemplateMap _templateMap;
		public static TemplateMap TemplateMap
		{
			get
			{
				if (_templateMap != null) return _templateMap;
				using (
					var reader =
						new StringReader(File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Config/FieldSettings.yml"))))
				{
					var deserializer = new Deserializer();
					_templateMap = deserializer.Deserialize<TemplateMap>(reader);
				}
				return _templateMap;
			} 
		}

	}
}